using CryptoWallet.WalletAPI.Models;

namespace CryptoWallet.WalletAPI.Repository
{
    public interface IUserBalanceRepository
    {

        Task<IEnumerable<UserBalance>> GetUserBalance(int userId);

        Task<UserBalance> GetBalanceByCoin(int userId, string coin);

        Task ChangeBalance(Transaction transaction);

        bool CheckBalance(int userId, string coin, decimal changeValue);

    }
}
