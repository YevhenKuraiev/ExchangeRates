using Acr.UserDialogs;
using ExchangeRates.Core.Models;
using ExchangeRates.Core.SQLite.Repositories;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRates.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private IRepository<ExchangeRatesDTO> exchangeRatesRepository;
        private readonly IMvxNavigationService navigationService;
        private readonly ExchangeRatesModel exchangeRatesModel = new ExchangeRatesModel();
        public MvxObservableCollection<ExchangeRatesDTO> Currencies => exchangeRatesModel.Currencies;

        public MvxCommand<ExchangeRatesDTO> ItemSelectedCommand => new MvxCommand<ExchangeRatesDTO>(ItemSelected);

        public FirstViewModel(IMvxNavigationService navigationService, IRepository<ExchangeRatesDTO> repository)
        {
            this.navigationService = navigationService;
            exchangeRatesRepository = repository;
        }

        public void ItemSelected(ExchangeRatesDTO item)
        {
            navigationService.Navigate<DetailViewModel, ExchangeRatesDTO>(item);

        }

        public override async void ViewAppearing()
        {
            await SetExchangeRates();
        }


        public async Task SetExchangeRates()
        {
            using (UserDialogs.Instance.Loading())
            {
                try
                {
                    List<ExchangeRatesDTO> list = await exchangeRatesRepository.Get<ExchangeRatesDTO>();
                    if (list.Count == 0)
                    {
                        await exchangeRatesModel.GetExchangeRatesAsync();
                        await exchangeRatesRepository.InsertAll(exchangeRatesModel.Currencies);
                    }
                    else
                    {
                        exchangeRatesModel.UpdateCurrencies(list);
                    }
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
