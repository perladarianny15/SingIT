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
using Prism.Commands;

namespace SINGIT.ViewModels
{
    public class TracksSearchPageViewModel: BaseViewModel, INotifyPropertyChanged, INavigationAware
    {       
        public ObservableCollection<Track> FavoriteList { get; set; } = new ObservableCollection<Track>();
        Track track { get; set; }
        INavigationService _navigationService;
		public DelegateCommand DeleteElementCommand { get; set; }


		public TracksSearchPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MessagingCenter.Subscribe<TracksSearchPageViewModel, Track>(this, "SendSelectedItem", ((sender, param) =>
            {
                FavoriteList.Add(param);
                MessagingCenter.Unsubscribe<TracksSearchPageViewModel, Track>(this, "SendSelectedItem");
            }));

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
                track = parameters.GetValue<Track>("SelectedItem");

            }
            MessagingCenter.Send<TracksSearchPageViewModel, Track>(this, "SendSelectedItem", track);

        }
    }
}
