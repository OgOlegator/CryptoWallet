using CryptoWallet.WalletAPI.Models;

namespace CryptoWallet.WalletAPI.Repository
{
    public interface ITransactHistoryRepository
    {

        Task<IEnumerable<TransactionHistory>> GetHistoryByUserId(int id);

        Task<TransactionHistory> AddTransaction(TransactionHistory transaction);

    }
}
