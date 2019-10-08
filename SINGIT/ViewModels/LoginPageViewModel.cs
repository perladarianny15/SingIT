using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Prism.Services;
using SINGIT.Helper;
using SINGIT.Models;
using SINGIT.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SINGIT.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public DelegateCommand ToHomePageCommand { get; set; }
        public DelegateCommand ToRegisterPageCommand { get; set; }
        protected INavigationService _navigationService;
        public LoginModel LoginModel { get; set; }
        public string Result { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;

            LoginModel = new LoginModel();

            try
            {
                ToHomePageCommand = new DelegateCommand(async () =>
                {
                    if (ConnectionValidation.HaveInternetConnection())
                    {
                        await LoginValidations(LoginModel);
                    }
                    else
                        await pageDialogService.DisplayAlertAsync(ErrorCodes.Error, ErrorCodes.NoInternet, ErrorCodes.Cancel);

                });

                ToRegisterPageCommand = new DelegateCommand(async () =>
                {
                    await ToRegisterPage();

                });
            }
            catch (Exception ex)
            {
                pageDialogService.DisplayAlertAsync(ErrorCodes.Error, ex.Message, ErrorCodes.Cancel);
            }
        }

        async Task ToRegisterPage()
        {
            await _navigationService.NavigateAsync(NavigationConstants.Register);

        }

        async Task ToHomePage()
        {
            await _navigationService.NavigateAsync(new Uri(NavigationConstants.Home, UriKind.Absolute));
        }

        async Task LoginValidations(LoginModel Login)
        {
            if (!UserValidations.IsnotEmpty(Login.UserName))
            {
                Result = ErrorCodes.UserNameRequired;
            }
            else if (!UserValidations.IsnotEmpty(Login.Password))
            {
                Result = ErrorCodes.PasswordRequired;
            }
            else
            {
                await ToHomePage();
            }

        }
    }
}
