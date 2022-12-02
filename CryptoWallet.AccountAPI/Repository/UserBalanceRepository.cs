using CryptoWallet.WalletAPI.DbContexts;
using CryptoWallet.WalletAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoWallet.WalletAPI.Repository
{
    public class UserBalanceRepository : IUserBalanceRepository
    {
        private readonly ApplicationDbContext _db;

        public UserBalanceRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<UserBalance>> GetUserBalance(int userId)
            => await _db.UserBalances.Where(rowBalance => rowBalance.UserId == userId).ToListAsync();

        public async Task<UserBalance> GetBalanceByCoin(int userId, string coin)
        {
            return await _db.UserBalances.FirstOrDefaultAsync(
                                rowBalance =>
                                rowBalance.UserId == userId
                                && rowBalance.Coin == coin);
        }
        
        public UserBalance GetNewRowUserBalance(int userId, string coin)
            => new UserBalance
            {
                UserId = userId,
                Coin = coin,
                Count = 0
            };

        public bool CheckBalance(int userId, string coin, decimal changeValue)
        {
            var balance = GetBalanceByCoin(userId, coin);

            return balance.Result.Count >= changeValue;
        }

        public async Task<UserBalance> IncreaseBalance(int userId, string coin, decimal count)
        {
            var userBalance = await GetBalanceByCoin(userId, coin);

            if(userBalance == null)
            {
                userBalance = new UserBalance
                {
                    UserId = userId,
                    Coin = coin,
                    Count = count
                };

                _db.UserBalances.Add(userBalance);
            }
            else
            {
                userBalance.Count += count;
                _db.UserBalances.Update(userBalance);
            }

            try
            {
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Не удалось обработать перевод");
            }

            return userBalance;
        }

        public async Task<UserBalance> DecreaseBalance(int userId, string coin, decimal count)
        {
            var userBalance = await GetBalanceByCoin(userId, coin);

            if (userBalance == null || userBalance.Count < count)
                throw new Exception("На счете недостаточно средств");

            userBalance.Count -= count;

            _db.UserBalances.Update(userBalance);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Не удалось обработать перевод");
            }

            return userBalance;
        }

        public async Task<Transaction> ExecuteTransaction(Transaction transaction)
        {
            using (var transactionDb = _db.Database.BeginTransaction())
            {
                await DecreaseBalance(transaction.SenderId, transaction.Coin, transaction.Count);
                await IncreaseBalance(transaction.RecipientId, transaction.Coin, transaction.Count);

                Task.WaitAll();

                transactionDb.Commit();
            };

            return transaction;
        }
    }
}
