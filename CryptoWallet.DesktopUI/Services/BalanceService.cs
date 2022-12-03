using CryptoWallet.DesktopUI.Model;
using CryptoWallet.DesktopUI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.DesktopUI.Services
{
    public class BalanceService : BaseService, IBalanceService
    {
        public BalanceService() : base() { }

        public async Task<T> GetBalance<T>(int userId)
        {
            return await SendAsync<T>(new ApiRequest
            {
                APIType = SD.APIType.GET,
                Url = SD.WalletApi + "/api/balance/" + userId
            });
        }

        public async Task<T> GetBalanceByCoin<T>(int userId, string coin)
        {
            return await SendAsync<T>(new ApiRequest
            {
                APIType = SD.APIType.GET,
                Url = SD.WalletApi + "/api/balance/" + userId + " " + coin
            });
        }

        public async Task<T> IncreaseBalance<T>(int userId, string coin, decimal count)
        {
            return await SendAsync<T>(new ApiRequest
            {
                APIType = SD.APIType.PUT,
                Url = SD.WalletApi + "/api/balance/" + userId + " " + coin + " " + count
            });
        }
    }
}
