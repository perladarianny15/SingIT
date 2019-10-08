using System;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using SINGIT.Helper;
using SINGIT.Services;
using SINGIT.ViewModels;
using SINGIT.Views;
using Xamarin.Forms;

namespace SINGIT
{
    public partial class App : PrismApplication
    {
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
    }
}
