using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SINGIT.ViewModels
{
    public class HomePageViewModel
    {
        
        public ObservableCollection<MasterPageItem> navigationDrawerList { get; set; } = new ObservableCollection<MasterPageItem>();

        public MasterPageItem Item { get; set; }

        public MasterPageItem SelectedContacts
        {
            get
            {
                return Item;
            }
            set
            {
                Item = value;
            }
        }
        public HomePageViewModel()
        {
            Item = new MasterPageItem();

            Item.Icon = "favorite.png";

            Item.Title = "Favorites";
            Item.Title = "Albums";
            Item.Icon = "music.png";
            Item.Title = "About The App";
            Item.Icon = "info.png";
            Item.Title = "Logout";
            Item.Icon = "logout.png";
            
            navigationDrawerList.Add(Item);
        }
    }
    public class MasterPageItem
    {
        public string Title
        {
            get;
            set;
        }
        public string Icon
        {
            get;
            set;
        }
    }
    
}
