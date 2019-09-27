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
    public class LoginPageViewModel : INotifyPropertyChanged , IInitialize
    {
        public DelegateCommand SaveLoginCommand { get; set; }
        public DelegateCommand ToRegisterPageCommand { get; set; }
        protected INavigationService _navigationService;
        public LoginModel loginModel { get; set; }
        public string Result { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;

            loginModel = new LoginModel();

            try
            {
                SaveLoginCommand = new DelegateCommand(async () =>
                {
                    if (ConnectionValidation.HaveInternetConnection())
                    {
                        await LoginValidations(loginModel);
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
               Application.Current.MainPage.DisplayAlert(ErrorCodes.Error, ex.Message, ErrorCodes.Cancel);
            }
        }

        async Task ToRegisterPage()
        {
            await _navigationService.NavigateAsync(NavigationConstants.NavigationConstants.Register);

        }

        async Task ToHomePage()
        {
            await _navigationService.NavigateAsync(NavigationConstants.NavigationConstants.Home);
        }

        async Task LoginValidations(LoginModel login)
        {
            if (!UserValidations.IsnotEmpty(login.UserName))
            {
                Result = ErrorCodes.UserNameRequired;
            }
            else if (!UserValidations.IsnotEmpty(login.Password))
            {
                Result = ErrorCodes.PasswordRequired;
            }
            else
            {
                await ToHomePage();
            }

        }
        public void Initialize(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
