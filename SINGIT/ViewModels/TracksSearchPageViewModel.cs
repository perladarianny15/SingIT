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
using static SINGIT.Models.TracksSearchModel;

namespace SINGIT.ViewModels
{
    public class TracksSearchPageViewModel: BaseViewModel, INotifyPropertyChanged
    {
        
        public  ICommand GetDataCommand { get; set; }
        public string q_artist { get; set; }
       
        public TracksSearchModel ArtistSearchDisplayList { get; set; }
        public ObservableCollection<TracksSearchModel> Tracks { get; set; }
        TracksSearchModel ReturnedMusicData = new TracksSearchModel();

        public TracksSearchPageViewModel()
        {
            MessagingCenter.Subscribe<SearchPageViewModel, Track>(this, "SendSelectedItem", ((sender, param) =>
            {
                MessagingCenter.Unsubscribe<SearchPageViewModel, Track>(this, "SendContact");
            }));
        }

    }
}
