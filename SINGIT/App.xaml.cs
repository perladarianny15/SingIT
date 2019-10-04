using System;
using System.IO;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using SINGIT.ViewModels;
using SINGIT.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SINGIT.NavigationConstants;
using SINGIT.Data;
namespace SINGIT
{
    public partial class App : PrismApplication
    {
        static SingItDatabase database;
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

            // containerRegistry.RegisterInstance<IApiService>(new ApiService());
        }

        public static SingItDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new SingItDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SingItSQLite.db3"));
                }
                return database;
            }
				
        }

        public int ResumeAtUserId { get; set; }
    }
}
