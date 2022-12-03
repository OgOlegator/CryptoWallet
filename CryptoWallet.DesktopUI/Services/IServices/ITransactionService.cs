using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.DesktopUI.Services.IServices
{
    public interface ITransactionService : IBaseService
    {

        Task<T> GetHistory<T>(int userId);

        Task<T> RunTransaction<T>(int senderId, int recipientId, string coin, decimal count);

    }
}
