using System;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using SINGIT.Helper;
using SINGIT.Services;
using SINGIT.ViewModels;
using SINGIT.Views;
using Xamarin.Forms;
using SINGIT.Data;
using SQLite;
using SQLiteNetExtensions;
using System.IO;
using SINGIT.Models;


namespace SINGIT
{
    public partial class App : PrismApplication
    {
        static SingItDataBase database;
      
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();


            NavigationService.NavigateAsync(NavigationConstants.Main);
            
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TabbedPage>();

            containerRegistry.RegisterForNavigation<MainPage, AccountPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();

            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<TracksSearchPage, TracksSearchPageViewModel>();
            containerRegistry.RegisterForNavigation<SearchPage, SearchPageViewModel>();

            containerRegistry.RegisterInstance<IApiService<ITracksByArtistsApi>>(new ApiService<ITracksByArtistsApi>(Config.ApiUrl));

            //containerRegistry.RegisterInstance<IApiService>(new ApiService());
        }

        public static SingItDataBase DatabasePath
        {
            get
            {
                if (database == null)
                {
                    database = new SingItDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SingItSQLite.db3"));
                }
                return database;
            }

        }
    }
}
