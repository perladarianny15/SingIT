using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using SINGIT.Helper;
using SINGIT.Views;
using Xamarin.Forms;

namespace SINGIT.ViewModels
{
    public class AccountPageViewModel
    {
        public DelegateCommand ToLoginPageCommand { get; set; }
        public DelegateCommand ToRegisterPageCommand { get; set; }
        protected INavigationService _navigationService;

        public AccountPageViewModel(INavigationService navigationService)
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
            await _navigationService.NavigateAsync(new Uri(NavigationConstants.Register, UriKind.Relative));

        }

        async Task ToLoginPage()
        {
            await _navigationService.NavigateAsync(new Uri(NavigationConstants.Login, UriKind.Relative));
        }
    }
}
