
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
        IUserDialogs _UserDialogs = UserDialogs.Instance;
        IConnectivity _Connectivity = CrossConnectivity.Current;
        IApiService<ITracksByArtistsApi> TracksByArtistApi;
        public bool IsConnected { get; set; }
        public bool IsReachable { get; set; }
        Dictionary<int, CancellationTokenSource> RunningTasks = new Dictionary<int, CancellationTokenSource>();
        Dictionary<string, Task<HttpResponseMessage>> TaskContainer = new Dictionary<string, Task<HttpResponseMessage>>();

        public ApiManager(IApiService<ITracksByArtistsApi> _trackByArtistApi)
        {
            TracksByArtistApi = _trackByArtistApi;
            IsConnected = _Connectivity.IsConnected;
            _Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            try
            {

                IsConnected = e.IsConnected;

                if (!e.IsConnected)
                {
                    var items = RunningTasks.ToList();
                    foreach (var item in items)
                    {
                        item.Value.Cancel();
                        RunningTasks.Remove(item.Key);
                    }
                }

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<HttpResponseMessage> GetTracksByArtist (string q_artist)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var Task = RemoteRequestAsync<HttpResponseMessage>(TracksByArtistApi.GetApi(Priority.UserInitiated).GetTracksByArtist(q_artist));
            RunningTasks.Add(Task.Id, cancellationTokenSource);

            return await Task;
        }
        protected async Task<TData> RemoteRequestAsync<TData>(Task<TData> task)
            where TData:HttpResponseMessage,
            new()
        {
            TData Data = new TData();
            try
            {
                if (!IsConnected)
                {
                    var strngResponse = ErrorCodes.NoInternet;
                    Data.StatusCode = HttpStatusCode.BadRequest;
                    Data.Content = new StringContent(strngResponse);

                    _UserDialogs.Toast(strngResponse, TimeSpan.FromSeconds(1));
                    return Data;
                }

                IsReachable = await _Connectivity.IsRemoteReachable(Config.ApiHostName);

                if (!IsReachable)
                {
                    var Response = ErrorCodes.NoInternet;
                    Data.StatusCode = HttpStatusCode.BadRequest;
                    Data.Content = new StringContent(Response);

                    _UserDialogs.Toast(Response, TimeSpan.FromSeconds(1));
                    return Data;
                }

                Data = await Policy
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
                    var Result = await task;
                    if (Result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new Exception(HttpStatusCode.Unauthorized.ToString());
                    }
                    return Result;
                });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return Data;
        }
    } 
}
