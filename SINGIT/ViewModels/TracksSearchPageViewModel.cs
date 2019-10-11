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
using SQLiteNetExtensions;
using SQLite;
using Prism.Navigation;
using Prism.Services;
using System.Linq;

namespace SINGIT.ViewModels
{
    public class TracksSearchPageViewModel: BaseViewModel, INotifyPropertyChanged, INavigationAware
    {
        
        public  ICommand GetDataCommand { get; set; }
        public string q_artist { get; set; }
       
        public TracksSearchModel ArtistSearchDisplayList { get; set; }
        public ObservableCollection<FavoriteSongsModel> FavoriteList { get; set; } = new ObservableCollection<FavoriteSongsModel>();
        FavoriteSongsModel FavoriteSongs { get; set; }

        public TracksSearchPageViewModel()
        {
          
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
            var element = parameters.Where(x => x.Value != null).FirstOrDefault().Value;
            if (element != null)
            {
                Track track = (Track)(object)element;

                FavoriteSongs.AlbumName = track.AlbumName;
                FavoriteSongs.Artist = track.ArtistName;
                FavoriteSongs.Year = track.FirstReleaseDate;
                FavoriteList.Add(FavoriteSongs);
            }
        }
    }
}
