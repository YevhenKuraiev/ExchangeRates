using ExchangeRates.Core.DTO;
using Flurl.Http;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Core.Models
{
    public class BankBranchesModel
    {
        private MvxObservableCollection<BankBranchesDTO> _bankBranches = new MvxObservableCollection<BankBranchesDTO>();
        public MvxObservableCollection<BankBranchesDTO> BankBranches => _bankBranches;


        public async Task GetBankBranchesAsync()
        {
            try
            {
                var result = await "https://api.privatbank.ua/p24api/pboffice?json&city=&address="
                .GetJsonAsync<MvxObservableCollection<BankBranchesDTO>>();
                if (result != null)
                {
                    _bankBranches = new MvxObservableCollection<BankBranchesDTO>(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
