﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using SINGIT.Helper;
using SINGIT.Services;
using Xamarin.Forms;

namespace SINGIT.ViewModels
{
    public class BaseViewModel:INotifyPropertyChanged
    {
        public IUserDialogs PageDialog = UserDialogs.Instance;
        public IApiManager ApiManager;
        IApiService<ITracksByArtistsApi> tracksByArtistApi = new ApiService<ITracksByArtistsApi>(Config.ApiUrl);
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy { get; set; }
        public BaseViewModel()
        {
            ApiManager = new ApiManager(tracksByArtistApi);
        }

        public async Task RunSafe(Task task, bool ShowLoading = true, string loadinMessage = null)
        {
            try
            {
                if (IsBusy) return;

                IsBusy = true;

                if (ShowLoading) UserDialogs.Instance.ShowLoading(loadinMessage ?? "Loading");

                await task;
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