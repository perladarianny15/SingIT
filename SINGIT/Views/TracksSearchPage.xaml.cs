using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SINGIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TracksSearchPage : ContentPage
    {
        ViewModels.TracksSearchPageViewModel _viewModel = new ViewModels.TracksSearchPageViewModel();
        public TracksSearchPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel;
        }
    }
}