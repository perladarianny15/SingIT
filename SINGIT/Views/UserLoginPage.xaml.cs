using System;
using System.Collections.Generic;
using SINGIT.ViewModels;
using Xamarin.Forms;

namespace SINGIT.Views
{
    public partial class UserLoginPage : ContentPage
    {
        public UserLoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }
    }
}
