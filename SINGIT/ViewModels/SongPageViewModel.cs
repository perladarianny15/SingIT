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
using System.Net.Http;

namespace SINGIT.ViewModels
{
    public class SongPageViewModel : BaseViewModel, INavigatedAware
    {
        INavigationService _navigationService;
        TracksSearchModel CurrentSong;
        public DelegateCommand SearchTrackCommand;
        public ObservableCollection<Track> SearchTrackList { get; set; } = new ObservableCollection<Track>();
        public string Result { get; set; }
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
            string TrackItemString = Convert.ToString(element);
            SearchTrackCommand = new DelegateCommand(async () => await RunSafe(GetData(TrackItemString)));
            //Result = "hola";
         

        }

        public async Task GetData(string TrackItem)
        {
            var TrackResponse = await ApiManager.GetLyrics(TrackItem);
            var response = await TrackResponse.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<LyricsModel>(response);
            Result = json.message.Body.Lyrics.Lyrics_body;


            /*HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("$https://api.musixmatch.com/ws/1.1/track.lyrics.get?format=jsonp&callback=callback&track_id={TrackItemString}");
            var json = JsonConvert.DeserializeObject<LyricsModel>(response);
            Result = json.message.Body.Lyrics.Lyrics_body;
            if (Result == null)
            {
                Result = "No se encontraron las letras para la cancion";
            }
            return Result;*/


        }

        
    }
}
