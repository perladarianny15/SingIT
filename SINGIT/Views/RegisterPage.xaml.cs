using System;
using System.Collections.Generic;
using SINGIT.ViewModels;
using Xamarin.Forms;

namespace SINGIT.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterPageViewModel();
        }
    }
}
