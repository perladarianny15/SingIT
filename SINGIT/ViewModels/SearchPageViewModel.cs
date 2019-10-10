using System;
using System.ComponentModel;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using SINGIT.Helper;

namespace SINGIT.ViewModels
{
    public class SearchPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected INavigationService _navigationService;
        public DelegateCommand SearchCommand { get; set; }

        public SearchPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            try
            {
                SearchCommand = new DelegateCommand(async () =>
                {
                    if (ConnectionValidation.HaveInternetConnection())
                    {

                       await pageDialogService.DisplayAlertAsync("OKey", "ok", "ok");
                    }
                    else
                        await pageDialogService.DisplayAlertAsync(ErrorCodes.Error, ErrorCodes.NoInternet, ErrorCodes.Cancel);

                });

            }
            catch(Exception ex)
            {

            }
        }
    }
}
