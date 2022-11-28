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

        public async Task ChangeBalance(TransactionHistory transaction)
        {

            var userBalanceRow1 = await GetBalanceByCoin(transaction.SenderId, transaction.Coin);
            var userBalanceRow2 = await GetBalanceByCoin(transaction.RecipientId, transaction.Coin);

            //Изменение баланса отправителя
            if (userBalanceRow1 == null || transaction.Count > userBalanceRow1.Count)
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

        public async Task<IEnumerable<UserBalance>> GetUserBalance(int id)
        {
            return await _db.UserBalances.Where(rowBalance => rowBalance.UserId == id).ToListAsync();
        }

        public async Task<UserBalance> GetBalanceByCoin(int id, string coin)
        {
            return await _db.UserBalances
                .FirstOrDefaultAsync(
                    rowBalance =>
                    rowBalance.UserId == id
                    && rowBalance.Coin == coin);
        }

        public UserBalance GetNewRowUserBalance(int id, string coin)
            => new UserBalance
            {
                UserId = id,
                Coin = coin,
                Count = 0
            };
    }
}
