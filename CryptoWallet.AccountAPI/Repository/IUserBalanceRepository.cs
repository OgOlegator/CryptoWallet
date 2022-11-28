using CryptoWallet.WalletAPI.Models;

namespace CryptoWallet.WalletAPI.Repository
{
    public interface IUserBalanceRepository
    {

        Task<IEnumerable<UserBalance>> GetUserBalance(int id);

        Task<UserBalance> GetBalanceByCoin(int id, string coin);

        Task ChangeBalance(TransactionHistory transaction);

    }
}
