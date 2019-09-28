﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Fusillade;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Polly;
using Refit;
using SINGIT.Helper;

namespace SINGIT.Services
{
    public class ApiManager : IApiManager
    {
        IUserDialogs _userDialogs = UserDialogs.Instance;
        IConnectivity _connectivity = CrossConnectivity.Current;
        IApiService<ITracksByArtistsApi> tracksByArtistApi;
        public bool IsConnected { get; set; }
        public bool IsReachable { get; set; }
        Dictionary<int, CancellationTokenSource> runningTasks = new Dictionary<int, CancellationTokenSource>();
        Dictionary<string, Task<HttpResponseMessage>> taskContainer = new Dictionary<string, Task<HttpResponseMessage>>();

        public ApiManager(IApiService<ITracksByArtistsApi> _trackByArtistApi)
        {
            tracksByArtistApi = _trackByArtistApi;
            IsConnected = _connectivity.IsConnected;
            _connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsConnected = e.IsConnected;

            if (!e.IsConnected)
            {
                var items = runningTasks.ToList();
                foreach (var item in items)
                {
                    item.Value.Cancel();
                    runningTasks.Remove(item.Key);
                }
            }
        }
        public async Task<HttpResponseMessage> GetTracksByArtist (string q_artist)
        {
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync<HttpResponseMessage>(tracksByArtistApi.GetApi(Priority.UserInitiated).GetTracksByArtist(q_artist));
            runningTasks.Add(task.Id, cts);

            return await task;
        }
        protected async Task<TData> RemoteRequestAsync<TData>(Task<TData> task)
            where TData:HttpResponseMessage,
            new()
        {
            TData data = new TData();
            try
            {
                if (!IsConnected)
                {
                    var strngResponse = ErrorCodes.NoInternet;
                    data.StatusCode = HttpStatusCode.BadRequest;
                    data.Content = new StringContent(strngResponse);

                    _userDialogs.Toast(strngResponse, TimeSpan.FromSeconds(1));
                    return data;
                }

                IsReachable = await _connectivity.IsRemoteReachable(Config.ApiHostName);

                if (!IsReachable)
                {
                    var strngResponse = ErrorCodes.NoInternet;
                    data.StatusCode = HttpStatusCode.BadRequest;
                    data.Content = new StringContent(strngResponse);

                    _userDialogs.Toast(strngResponse, TimeSpan.FromSeconds(1));
                    return data;
                }

                data = await Policy
                .Handle<WebException>()
                .Or<ApiException>()
                .Or<TaskCanceledException>()
                .WaitAndRetryAsync
                (
                    retryCount: 1,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                )
                .ExecuteAsync(async () =>
                {
                    var result = await task;
                    if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                    }
                    return result;
                });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return data;
        }
    } 
}