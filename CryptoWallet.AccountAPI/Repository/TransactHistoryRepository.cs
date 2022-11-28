using CryptoWallet.WalletAPI.DbContexts;
using CryptoWallet.WalletAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoWallet.WalletAPI.Repository
{
    public class TransactHistoryRepository : ITransactHistoryRepository
    {

        private readonly ApplicationDbContext _db;

        public TransactHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<TransactionHistory> AddTransaction(TransactionHistory transaction)
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

        public async Task<IEnumerable<TransactionHistory>> GetHistoryByUserId(int id)
        {
            return await _db.History.Where(row => row.SenderId == id || row.RecipientId == id).ToListAsync();
        }
    }
}
