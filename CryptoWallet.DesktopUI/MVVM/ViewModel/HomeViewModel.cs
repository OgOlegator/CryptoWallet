using CryptoWallet.DesktopUI.Core;
using CryptoWallet.DesktopUI.Model;
using CryptoWallet.DesktopUI.MVVM.Model;
using CryptoWallet.DesktopUI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.DesktopUI.MVVM.ViewModel
{
    public class HomeViewModel : ObservableObject
    {
        public ObservableCollection<Balance> Balances { get; set; } = new ObservableCollection<Balance>();

        public HomeViewModel()
        {
            SetBalances();
        }

        private async void SetBalances()
        {
            var balanceService = new BalanceService();

            var response = await balanceService.GetBalance<ResponseDto>(2);

            if (!response.IsSuccess || response.Result == null)
                return;

            var listBalances = JsonConvert.DeserializeObject<IEnumerable<UserBalanceDto>>(Convert.ToString(response.Result));

            foreach (var rowBalance in listBalances.Select(x => new Balance { Coin = x.Coin, Count = x.Count }))
                Balances.Add(rowBalance);
        }
    }
}
