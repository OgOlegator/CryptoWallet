using CryptoWallet.DesktopUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.DesktopUI.Services.IServices
{
    public interface IUserDataService : IBaseService
    {

        Task<T> GetUserInformation<T>(int userId);

        Task<T> CreateUser<T>(UserDto user);

    }
}
