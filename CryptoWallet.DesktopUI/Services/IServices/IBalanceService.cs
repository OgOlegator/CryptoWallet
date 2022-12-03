using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.DesktopUI.Services.IServices
{
    public interface IBalanceService : IBaseService
    {

        Task<T> GetBalance<T>(int userId);

        Task<T> GetBalanceByCoin<T>(int userId, string coin);

        Task<T> IncreaseBalance<T>(int userId, string coin, decimal count);

    }
}
