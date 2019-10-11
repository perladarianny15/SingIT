
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
        public bool IsConnected { get; set; }
        public bool IsReachable { get; set; }
        Dictionary<int, CancellationTokenSource> RunningTasks = new Dictionary<int, CancellationTokenSource>();
        Dictionary<string, Task<HttpResponseMessage>> TaskContainer = new Dictionary<string, Task<HttpResponseMessage>>();
        IApiService<ITracksByArtistsApi> TracksByArtistApi;
        IApiService<IArtistServices> ArtistService;
        IApiService<IAlbumService> AlbumService;
        IApiService<ITracksByArtistsApi> TrackByID;


        public ApiManager(IApiService<ITracksByArtistsApi> _TrackByArtistApi,
            IApiService<IArtistServices> _ArtistServices,
            IApiService<IAlbumService> _albumService)
        {
            TracksByArtistApi = _TrackByArtistApi;
            ArtistService = _ArtistServices;
            AlbumService = _albumService;
            IsConnected = _Connectivity.IsConnected;
            _Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        public ApiManager(IApiService<ITracksByArtistsApi> tracksByArtistApi, IApiService<IArtistServices> artistService, IApiService<IAlbumService> albumService, IApiService<ITracksByArtistsApi> trackByID)
        {
            TracksByArtistApi = tracksByArtistApi;
            ArtistService = artistService;
            AlbumService = albumService;
            TrackByID = trackByID;
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

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<HttpResponseMessage> GetTracksByArtist(string q_artist)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var Task = RemoteRequestAsync<HttpResponseMessage>(TracksByArtistApi.GetApi(Priority.UserInitiated).GetTracksByArtist(q_artist));
            RunningTasks.Add(Task.Id, cancellationTokenSource);

            return await Task;
        }

        public async Task<HttpResponseMessage> GetArtist(string ArtistName)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var Task = RemoteRequestAsync<HttpResponseMessage>(ArtistService.GetApi(Priority.UserInitiated).GetArtistByName(ArtistName));
            RunningTasks.Add(Task.Id, cancellationTokenSource);

            return await Task;
        }

        public Task<HttpResponseMessage> GetAlbumByName(string Album)
        {
            throw new NotImplementedException();
        }
        protected async Task<TData> RemoteRequestAsync<TData>(Task<TData> task)
            where TData : HttpResponseMessage,
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Data;
        }

        public async Task<HttpResponseMessage> GetTrackByID(string TrackID)
        {
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync<HttpResponseMessage>(TracksByArtistApi.GetApi(Priority.UserInitiated).GetTrackByID(TrackID));
            RunningTasks.Add(task.Id, cts);

            return await task;
        }
    }
}
