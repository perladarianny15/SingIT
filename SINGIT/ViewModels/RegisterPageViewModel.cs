using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using SINGIT.Helper;
using SINGIT.Models;
using SINGIT.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SINGIT.ViewModels
{
    public class RegisterPageViewModel: INotifyPropertyChanged
    {
        public DelegateCommand SaveRegisterCommand { get; set; }
        public RegisterModel registerModel { get; set; }
        public string Result { get; set; }
        public string ConfirmPassword { get; set; }
        protected INavigationService _navigationService;
        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            registerModel = new RegisterModel();
            try
            {
                SaveRegisterCommand = new DelegateCommand(async () =>
                {
                    if (ConnectionValidation.HaveInternetConnection())
                    {
                       // await RegisterValidations(registerModel);
                        await App.Database.SaveItemAsync(registerModel);///Added
                        RegisterModel holamigo= await App.Database.GetUserAsync(0);
                        int i = 0;
                        await _navigationService.NavigateAsync(NavigationConstants.NavigationConstants.Home);
                    }
                    else
                        await pageDialogService.DisplayAlertAsync(ErrorCodes.Error, ErrorCodes.NoInternet, ErrorCodes.Cancel);

                });

            }
            catch (Exception ex)
            {
                pageDialogService.DisplayAlertAsync(ErrorCodes.Error, ex.Message, ErrorCodes.Cancel);

            }
        }
        async Task RegisterValidations(RegisterModel register)
        {
            if (!UserValidations.IsnotEmpty(register.UserName))
            {
                Result = ErrorCodes.UserNameRequired;
            }
            else if (!UserValidations.IsnotEmpty(register.Password))
            {
                Result = ErrorCodes.PasswordRequired;
            }
            else if (!UserValidations.IsEqual(register.Password, ConfirmPassword))
            {

                Result = ErrorCodes.PassNoMatch;
            }
            else if (!UserValidations.IsnotEmpty(register.Email))
            {
                Result = ErrorCodes.UserEmailRequired;
            }
            else if (!UserValidations.NumberIsNotEmpty(register.Number))
            {
                Result = ErrorCodes.TelNumberRequired;
            }
            else
            {
                return;
               //await ToHomePage();
            }
        }
        async Task ToHomePage()
        {
            await _navigationService.NavigateAsync(NavigationConstants.NavigationConstants.Home);
        }
    }
}
