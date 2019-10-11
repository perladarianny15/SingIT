using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using SINGIT.Helper;
using SINGIT.Services;
using Xamarin.Forms;
using SINGIT.Models;
using System.Windows.Input;
using Prism.Navigation;

namespace SINGIT.ViewModels
{
    public class BaseViewModel:INotifyPropertyChanged
    {
      
        public IUserDialogs PageDialog = UserDialogs.Instance;
        public IApiManager ApiManager;
        public event PropertyChangedEventHandler PropertyChanged;
        IApiService<ITracksByArtistsApi> TracksByArtistApi = new ApiService<ITracksByArtistsApi>(Config.ApiUrl);
        IApiService<IArtistServices> ArtistService = new ApiService<IArtistServices>(Config.ApiUrl);
        IApiService<IAlbumService> AlbumService = new ApiService<IAlbumService>(Config.ApiUrl);
        public bool IsBusy { get; set; }

        public BaseViewModel()
        {
            ApiManager = new ApiManager(TracksByArtistApi, ArtistService, AlbumService);
        }

        public async Task RunSafe(Task Task, bool ShowLoading = true, string LoadinMessage = null)
        {
            try
            {
                if (IsBusy) return;

                IsBusy = true;

                if (ShowLoading) UserDialogs.Instance.ShowLoading(LoadinMessage ?? "Loading");

                await Task;
            }
            catch (Exception e)
            {
                IsBusy = false;
                UserDialogs.Instance.HideLoading();
                Debug.WriteLine(e.ToString());
                await Application.Current.MainPage.DisplayAlert(ErrorCodes.Error, ErrorCodes.CheckConnection, ErrorCodes.Ok);

            }
            finally
            {
                IsBusy = false;
                if (ShowLoading) UserDialogs.Instance.HideLoading();
            }
        }
    }
}
