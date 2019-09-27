using System;
using System.ComponentModel;
using System.Windows.Input;
using SINGIT.Helper;
using SINGIT.Models;
using SINGIT.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SINGIT.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public ICommand SaveLoginCommand { get; set; }
        public ICommand ToRegisterPage { get; set; }
        public LoginModel login { get; set; }
        public string Result { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginPageViewModel()
        {
            login = new LoginModel();

            try
            {
                SaveLoginCommand = new Command(async () =>
                {
                    if (ConnectionValidation.HaveInternetConnection())
                    {
                        if (!UserValidations.IsnotEmpty(login.UserName))
                        {
                            Result = "El nombre de usuario es requerido";
                        }
                        else if (!UserValidations.IsnotEmpty(login.Password))
                        {
                            Result = "La contraseña es requerida.";
                        }
                        else
                        {
                            //await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new ContactListPage() { BackgroundColor = Color.CadetBlue }));

                        }
                    }
                    else
                        await Application.Current.MainPage.DisplayAlert("Error", "No tiene conexion a internet", "Cancel");

                });

                ToRegisterPage = new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());

                });
            }
            catch (Exception ex)
            {
               Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");
            }
        }
    }
}
