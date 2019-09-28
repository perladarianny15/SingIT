using System;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using SINGIT.ViewModels;
using SINGIT.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SINGIT.NavigationConstants;

namespace SINGIT
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync(NavigationConstants.NavigationConstants.Main);
            
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TabbedPage>();
            containerRegistry.RegisterForNavigation<MainPage, AccountViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, AccountViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<TracksSearchPage, TracksSearchPageViewModel>();

            // containerRegistry.RegisterInstance<IApiService>(new ApiService());
        }
    }
}
