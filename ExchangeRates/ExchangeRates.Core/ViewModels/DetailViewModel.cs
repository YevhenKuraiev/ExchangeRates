using ExchangeRates.Core.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ExchangeRates.Core.ViewModels
{
    class DetailViewModel : MvxViewModel<ExchangeRatesDTO>
    {
        private readonly IMvxNavigationService _navigationService;
        private DetailModel _detailModel;
        public ExchangeRatesDTO ExchangeRates => _detailModel.ExchangeRates;
        public ICommand SaveCommand => new MvxCommand<string>(Save);

        public DetailViewModel(IMvxNavigationService mvxNavigationService)
        {
            _navigationService = mvxNavigationService;
        }


        public void Save(string code)
        {
            _navigationService.Close(this);
        }

        public override void Prepare(ExchangeRatesDTO parameter)
        {
            _detailModel = new DetailModel(parameter);
        }
    }
}
