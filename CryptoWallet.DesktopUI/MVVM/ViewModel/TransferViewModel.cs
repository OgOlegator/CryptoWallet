using CryptoWallet.DesktopUI.Core;
using CryptoWallet.DesktopUI.Model;
using CryptoWallet.DesktopUI.MVVM.Model;
using CryptoWallet.DesktopUI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.DesktopUI.MVVM.ViewModel
{
    public class TransferViewModel : ObservableObject
    {
        public TransferViewModel()
        {

        }

        private string? _message;
        private int _recipentId;
        private string? _coin;
        private decimal _count;

        public string? Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        public string? RecipentId 
        {
            get { return _recipentId.ToString(); }
            set
            {
                _recipentId = int.Parse(value);
                OnPropertyChanged("RecipentId");
            }
        }

        public string? Coin
        {
            get { return _coin; }
            set
            {
                _coin = value;
                OnPropertyChanged("Coin");
            }
        }

        public string? Count
        {
            get { return _count.ToString(); }
            set
            {
                _count = decimal.Parse(value);
                OnPropertyChanged("Count");
            }
        }

        public RelayCommand SendClick
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (!VerifyModel())
                        return;

                    RunTransaction();
                });
            }
        }

        private async void RunTransaction()
        {
            var transactionService = new TransactionService();

            var response = await transactionService.RunTransaction<ResponseDto>(2, _recipentId, _coin, _count);

            if (!response.IsSuccess || response.Result == null)
                return;

            var resultTransaction = JsonConvert.DeserializeObject<TransactionDto>(Convert.ToString(response.Result));

            Message = "Выполнено";
        }

        private bool VerifyModel()
        {
            if(string.IsNullOrWhiteSpace(RecipentId) 
                || string.IsNullOrWhiteSpace(Coin)
                || string.IsNullOrWhiteSpace(Count))
            {
                Message = "Не все поля заполнены";
                return false;
            }

            if(_count <= 0)
            {
                Message = "Ввдеите допустимое количество";
                return false;
            }

            return true;
        }
    }
}
