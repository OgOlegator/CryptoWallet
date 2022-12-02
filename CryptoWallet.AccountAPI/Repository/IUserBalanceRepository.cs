using CryptoWallet.WalletAPI.Models;

namespace CryptoWallet.WalletAPI.Repository
{
    public interface IUserBalanceRepository
    {

        Task<IEnumerable<UserBalance>> GetUserBalance(int userId);

        Task<UserBalance> GetBalanceByCoin(int userId, string coin);

        bool CheckBalance(int userId, string coin, decimal changeValue);

        Task<UserBalance> IncreaseBalance(int userId, string coin, decimal count);

        Task<UserBalance> DecreaseBalance(int userId, string coin, decimal count);

        Task<Transaction> ExecuteTransaction(Transaction transaction);

    }
}
