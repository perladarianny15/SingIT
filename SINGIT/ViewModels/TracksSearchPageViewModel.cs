using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using SINGIT.Models;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;



namespace SINGIT.ViewModels
{
    public class TracksSearchPageViewModel: BaseViewModel,INotifyPropertyChanged
    {
        
        public  ICommand GetDataCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public string q_artist { get; set; }
       
        public TrackSearchObject ArtistSearchDisplayList { get; set; }
        public ObservableCollection<TrackSearchObject> Tracks { get; set; }

        public TracksSearchPageViewModel()
        {
            GetDataCommand = new Command(async () => await RunSafe(GetData()));
            
        }

        async Task GetData()
        {

            var tracksResponse = await ApiManager.GetTracksByArtist("Queen");

            if (tracksResponse.IsSuccessStatusCode)
            {
                var response = await tracksResponse.Content.ReadAsStringAsync();
                var json = await Task.Run(() => JsonConvert.DeserializeObject<List<TrackSearchObject>>(response));
                Tracks = new ObservableCollection<TrackSearchObject>(json);
            }
            else
            {
                await PageDialog.AlertAsync("Unable to get data", "Error", "Ok");
            }
        }


    }
}
