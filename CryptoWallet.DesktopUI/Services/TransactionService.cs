using CryptoWallet.DesktopUI.Model;
using CryptoWallet.DesktopUI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.DesktopUI.Services
{
    public class TransactionService : BaseService, ITransactionService
    {
        public TransactionService() : base() { }

        public async Task<T> GetHistory<T>(int userId)
        {
            return await SendAsync<T>(new ApiRequest
            {
                APIType = SD.APIType.GET,
                Url = SD.WalletApi + "/api/transaction/" + userId
            });
        }

        public async Task<T> RunTransaction<T>(int senderId, int recipientId, string coin, decimal count)
        {
            return await SendAsync<T>(new ApiRequest
            {
                APIType = SD.APIType.PUT,
                Url = SD.WalletApi + "/api/transaction/" + senderId + " " + recipientId + " " + coin + " " + count,
            });
        }
    }
}
