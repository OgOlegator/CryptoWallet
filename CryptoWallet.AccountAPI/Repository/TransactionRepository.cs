using CryptoWallet.WalletAPI.DbContexts;
using CryptoWallet.WalletAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoWallet.WalletAPI.Repository
{
    public class TransactionRepository : ITransactionRepository
    {

        private readonly ApplicationDbContext _db;

        public TransactionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            try
            {
                _db.History.Add(transaction);

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Не удалось добавить транзакцию в историю");
            }

            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetHistoryByUserId(int id)
        {
            return await _db.History.Where(row => row.SenderId == id || row.RecipientId == id).ToListAsync();
        }
    }
}
