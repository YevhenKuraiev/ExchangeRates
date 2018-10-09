using Acr.UserDialogs;
using ExchangeRates.Core.DTO;
using ExchangeRates.Core.Models;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRates.Core.ViewModels
{
    public class BankBranchesViewModel : MvxViewModel<BankBranchesDTO>
    {
        private BankBranchesModel _bankBranchesModel = new BankBranchesModel();
        public MvxObservableCollection<BankBranchesDTO> BankBranches => _bankBranchesModel.BankBranches;
        public override void Prepare(BankBranchesDTO parameter)
        {
            
        }


        public override async void ViewAppeared()
        {
            using (UserDialogs.Instance.Loading())
            {
                try
                {
                    await _bankBranchesModel.GetBankBranchesAsync();
                    RaisePropertyChanged("BankBranches");
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.Alert(ex.Message, "Error");
                }
            }

        }
    }
}
