using CryptoWallet.DesktopUI.Model;
using CryptoWallet.DesktopUI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CryptoWallet.DesktopUI.Services
{
    public class UserDataService : BaseService, IUserDataService
    {
        public UserDataService() : base() { }

        public async Task<T> CreateUser<T>(UserDto user)
        {
            return await SendAsync<T>(new ApiRequest
            {
                APIType = SD.APIType.POST,
                Data = user,
                Url = SD.WalletApi + "/api/account",
            });
        }

        public async Task<T> GetUserInformation<T>(int userId)
        {
            return await SendAsync<T>(new ApiRequest
            {
                APIType = SD.APIType.GET,
                Url = SD.WalletApi + "/api/account/" + userId
            });
        }
    }
}
