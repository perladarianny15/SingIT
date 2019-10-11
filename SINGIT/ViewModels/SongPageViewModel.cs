using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using SINGIT.Models;
using Prism.Commands;
using Prism.Services;
using SINGIT.Helper;
using SINGIT.Models;
using Prism.Mvvm;
using Prism.Services;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using static SINGIT.Models.TracksSearchModel;

namespace SINGIT.ViewModels
{
    public class SongPageViewModel : BaseViewModel, INavigatedAware
    {
        INavigationService _navigationService;
        TracksSearchModel CurrentSong;
        public DelegateCommand SearchTrackCommand;
        public ObservableCollection<Track> SearchTrackList { get; set; } = new ObservableCollection<Track>();
        public SongPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            
        }
 
       
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }


        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var element = parameters["MyParam"];
            SearchTrackCommand = new DelegateCommand(async () => await RunSafe(GetData(element)));
        }

        async Task GetData(object TrackID)
        {
            string StringTrackID = Convert.ToString(TrackID);
            var TrackResponse = await ApiManager.GetTrackByID(StringTrackID);
            if (TrackResponse.IsSuccessStatusCode)
            {
                var response = await TrackResponse.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<TracksSearchModel>(response);
                foreach (var item in json.message.Body.TrackList)
                {
                    SearchTrackList.Add(item.Track);

                }
            }

        }
    }
}
