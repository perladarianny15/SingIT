using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using SINGIT.Models;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using SINGIT.Helper;

namespace SINGIT.ViewModels
{
    public class TracksSearchPageViewModel: BaseViewModel, INotifyPropertyChanged
    {
        
        public  ICommand GetDataCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public string q_artist { get; set; }
       
        public TracksSearchModel ArtistSearchDisplayList { get; set; }
        public ObservableCollection<TracksSearchModel> Tracks { get; set; }
        TracksSearchModel ReturnedMusicData = new TracksSearchModel();

        public TracksSearchPageViewModel()
        {
            GetDataCommand = new Command(async () => await RunSafe(GetData()));
            
        }

        async Task GetData()
        {
            try
            {

                var tracksResponse = await ApiManager.GetTracksByArtist("Queen");

                if (tracksResponse.IsSuccessStatusCode)
                {
                    var response = await tracksResponse.Content.ReadAsStringAsync();
                    ReturnedMusicData = await Task.Run(() => JsonConvert.DeserializeObject<TracksSearchModel>(response));
                    //Tracks = new ObservableCollection<TracksSearchModel>(ReturnedMusicData);
                }
                else
                {
                    await PageDialog.AlertAsync(ErrorCodes.UnableToConnect, ErrorCodes.Error, ErrorCodes.Ok);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
