using CryptoWallet.WalletAPI.Models;

namespace CryptoWallet.WalletAPI.Repository
{
    public interface ITransactionRepository
    {

        Task<IEnumerable<Transaction>> GetHistoryByUserId(int id);

        Task<Transaction> AddTransaction(Transaction transaction);

    }
}
