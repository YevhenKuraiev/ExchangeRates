using Acr.UserDialogs;
using ExchangeRates.Core.Models;
using Flurl.Http;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ExchangeRates.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ExchangeRatesModel exchangeRatesModel = new ExchangeRatesModel();
        public MvxObservableCollection<ExchangeRatesDTO> Currencies => exchangeRatesModel.Currencies;

        public MvxCommand<ExchangeRatesDTO> ItemSelectedCommand => new MvxCommand<ExchangeRatesDTO>(ItemSelected);

        public FirstViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void ItemSelected(ExchangeRatesDTO item)
        {
            _navigationService.Navigate<DetailViewModel, ExchangeRatesDTO>(item);

        }

        public override async void ViewAppearing()
        {
            using (UserDialogs.Instance.Loading())
            {
                try
                {
                    await exchangeRatesModel.GetExchangeRatesAsync();
                    RaisePropertyChanged("Currencies");
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.Alert(ex.Message, "Error");
                }
            }
        }


    }
}
