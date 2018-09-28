using Acr.UserDialogs;
using ExchangeRates.Core.Models;
using Flurl.Http;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using System;
using System.Threading.Tasks;

namespace ExchangeRates.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        public MvxObservableCollection<ExchangeRatesModel> Currencies { get; set; }


        public override async void ViewAppearing()
        {
            using (UserDialogs.Instance.Loading())
            {
                try
                {
                    var result = await "https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5"
                    .GetJsonAsync<MvxObservableCollection<ExchangeRatesModel>>();
                    if (result != null)
                    {
                        Currencies = new MvxObservableCollection<ExchangeRatesModel>(result);
                    }
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.Alert(ex.Message, "Error");
                }
            }
        }

        public FirstViewModel()
        {

        }
    }
}
