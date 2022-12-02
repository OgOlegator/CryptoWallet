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

        public async Task ChangeBalance(Transaction transaction)
        {
            var userBalanceRow1 = await GetBalanceByCoin(transaction.SenderId, transaction.Coin);
            var userBalanceRow2 = await GetBalanceByCoin(transaction.RecipientId, transaction.Coin);

            //Изменение баланса отправителя
            if (transaction.Count > userBalanceRow1.Count)
                throw new Exception("На счете недостаточно средств");

            userBalanceRow1.Count -= transaction.Count;
            _db.UserBalances.Update(userBalanceRow1);

            //Изменение баланса получателя
            if (userBalanceRow2 != null)
            {
                userBalanceRow2.Count += transaction.Count;
                _db.UserBalances.Update(userBalanceRow2);
            }
            else
            {
                userBalanceRow2 = GetNewRowUserBalance(transaction.RecipientId, transaction.Coin);
                userBalanceRow2.Count += transaction.Count;

                _db.UserBalances.Add(userBalanceRow2);
            }

            try
            {
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Не удалось обработать перевод");
            }
        }

        public async Task<IEnumerable<UserBalance>> GetUserBalance(int userId)
            => await _db.UserBalances.Where(rowBalance => rowBalance.UserId == userId).ToListAsync();

        public async Task<UserBalance> GetBalanceByCoin(int userId, string coin)
        {
            var balance = await _db.UserBalances.FirstOrDefaultAsync(
                                rowBalance =>
                                rowBalance.UserId == userId
                                && rowBalance.Coin == coin);

            return balance != null ? balance : new UserBalance { UserId = userId, Coin = coin, Count = 0 };
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
    }
}
