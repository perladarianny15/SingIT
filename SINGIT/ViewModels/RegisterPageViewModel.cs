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
    public class RegisterPageViewModel: INotifyPropertyChanged
    {
        public ICommand SaveRegisterCommand { get; set; }
        public RegisterModel register { get; set; }
        public string Result { get; set; }
        public string ConfirmPassword { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterPageViewModel()
        {
            register = new RegisterModel();
            try
            {
                SaveRegisterCommand = new Command(async () =>
                {
                    if (ConnectionValidation.HaveInternetConnection())
                    {
                        if (!UserValidations.IsnotEmpty(register.UserName))
                        {
                            Result = "El nombre de usuario es requerido";
                        }
                        else if (!UserValidations.IsnotEmpty(register.Password))
                        {
                            Result = "La contraseña es requerida.";
                        }
                        else if (!UserValidations.IsEqual(register.Password, ConfirmPassword))
                        {

                            Result = "Las contraseñas no coinciden";
                        }
                        else if (!UserValidations.IsnotEmpty(register.Email))
                        {
                            Result = "El Email es requerido";
                        }
                        else if (!UserValidations.NumberIsNotEmpty(register.Number))
                        {
                            Result = "El numero es requerido";
                        }
                        else
                        {
                            //await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new ContactListPage() { BackgroundColor = Color.CadetBlue }));
                        }
                    }
                    else
                        await Application.Current.MainPage.DisplayAlert("Error", "No tiene conexion a internet", "Cancel");

                });

            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");

            }
        }
    }
}
