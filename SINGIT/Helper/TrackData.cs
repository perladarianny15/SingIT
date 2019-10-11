using System;
using System.Collections.ObjectModel;
using SINGIT.Models;
using SINGIT.ViewModels;
using Xamarin.Forms;
using static SINGIT.Models.TracksSearchModel;

namespace SINGIT.Helper
{
    public class TrackData
    {
        public ObservableCollection<FavoriteSongsModel> FavoriteList { get; set; } = new ObservableCollection<FavoriteSongsModel>();
        FavoriteSongsModel FavoriteSongs { get; set; }
        public ObservableCollection<FavoriteSongsModel> TrackDataInfo()
        {
            FavoriteSongs = new FavoriteSongsModel();

            MessagingCenter.Subscribe<SearchPageViewModel, Track>(this, "SendSelectedItem", ((sender, param) =>
            {
                FavoriteSongs.Artist = param.ArtistName;
                FavoriteSongs.SongName = param.TrackName;
                FavoriteSongs.Year = param.FirstReleaseDate;
                FavoriteList.Add(FavoriteSongs);
                MessagingCenter.Unsubscribe<SearchPageViewModel, Track>(this, "SendSelectedItem");
            }));

            return FavoriteList;
        }
    }
}
