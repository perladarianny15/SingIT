using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using SINGIT.Views;
using Xamarin.Forms;

namespace SINGIT.ViewModels
{
    public class AccountViewModel
    {
        public DelegateCommand ToLoginPageCommand { get; set; }
        public DelegateCommand ToRegisterPageCommand { get; set; }
        protected INavigationService _navigationService;
        public AccountViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ToRegisterPageCommand = new DelegateCommand(async () =>
            {
                await ToRegisterPage();
            });

            ToLoginPageCommand = new DelegateCommand(async () =>
            {
                await ToLoginPage();
            });
        }
        async Task ToRegisterPage()
        {
            await _navigationService.NavigateAsync(NavigationConstants.NavigationConstants.Register);

        }

        async Task ToLoginPage()
        {
            //await _navigationService.NavigateAsync("/TracksSearchPage");

            await _navigationService.NavigateAsync(NavigationConstants.NavigationConstants.Login);
        }
    }
}
