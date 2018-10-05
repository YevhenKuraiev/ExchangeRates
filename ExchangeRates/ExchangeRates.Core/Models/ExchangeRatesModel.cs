using Flurl.Http;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Core.Models
{
    public class ExchangeRatesModel
    {
        private MvxObservableCollection<ExchangeRatesDTO> _currencies = new MvxObservableCollection<ExchangeRatesDTO>();
        public MvxObservableCollection<ExchangeRatesDTO> Currencies => _currencies;

        public ExchangeRatesModel()
        {
        }


        public void UpdateCurrencies(List<ExchangeRatesDTO> list)
        {
            _currencies = new MvxObservableCollection<ExchangeRatesDTO>(list);
        }


        public async Task GetExchangeRatesAsync()
        {
            try
            {
                var result = await "https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5"
                .GetJsonAsync<MvxObservableCollection<ExchangeRatesDTO>>();
                if (result != null)
                {
                    _currencies = new MvxObservableCollection<ExchangeRatesDTO>(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
