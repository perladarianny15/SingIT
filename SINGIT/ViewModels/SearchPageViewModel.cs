using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using SINGIT.Helper;
using SINGIT.Models;
using SINGIT.Services;
using Xamarin.Forms;
using static SINGIT.Models.TracksSearchModel;

namespace SINGIT.ViewModels
{
    public class SearchPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        protected INavigationService _navigationService;
        public DelegateCommand SearchCommand { get; set; }
        TracksSearchModel ReturnedMusicData = new TracksSearchModel();
        public ObservableCollection<Track> SearchTrackList { get; set; } = new ObservableCollection<Track>();
        public DelegateCommand AddToFavoriteCommand { get; set; }
        Track _SelectedItem = new Track();
        private string _searchedText;
        public string SearchedText
        {
            get
            {
                return _searchedText;
            }
            set
            {
                _searchedText = value;

            }
        }
        public Track SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
                if(_searchedText!=null)
                    OnSelectItem(_SelectedItem);
            }
        }

        public SearchPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;

            try
            {
                if (ConnectionValidation.HaveInternetConnection())
                {
                    SearchCommand = new DelegateCommand(async () => await RunSafe(GetData(SearchedText)));
                    
                }
                else
                    pageDialogService.DisplayAlertAsync(ErrorCodes.Error, ErrorCodes.NoInternet, ErrorCodes.Cancel);

                async Task GetData(string SearchText)
                {
                    try
                    {
                        var TracksResponse = await ApiManager.GetTracksByArtist(SearchText);

                        if (TracksResponse.IsSuccessStatusCode)
                        {
                            var response = await TracksResponse.Content.ReadAsStringAsync();
                            var json = JsonConvert.DeserializeObject<TracksSearchModel>(response);

                            foreach (var item in json.message.Body.TrackList)
                            {
                               SearchTrackList.Add(item.Track);
                                
                            }
                        }
                        else
                        {
                            await PageDialog.AlertAsync(ErrorCodes.NoDataToShow, ErrorCodes.Error, ErrorCodes.Ok);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        async void OnSelectItem(Track SelectedItem)
        {
           string result = await Application.Current.MainPage.DisplayActionSheet(StringStruct.Options,StringStruct.SongsInfo, ErrorCodes.Cancel, StringStruct.Favorite);
            if(result != null)
            {
                var navigationParams = new NavigationParameters();
                navigationParams.Add("SelectedItem", SelectedItem);
                await _navigationService.NavigateAsync(NavigationConstants.Favorite, navigationParams);
                switch (result)
                {
                    case StringStruct.Options:
                        break;
                    case StringStruct.Favorite:
                        break;
                    case StringStruct.SongsInfo:
                        var parameter = new NavigationParameters();
                        parameter.Add("MyParam",SelectedItem.TrackId);
                        await _navigationService.NavigateAsync(NavigationConstants.SongPage, parameter); ;
                        break;
                }
                //MessagingCenter.Send<SearchPageViewModel, Track>(this, "SendSelectedItem", SelectedItem);

            }
        }
    }
}
