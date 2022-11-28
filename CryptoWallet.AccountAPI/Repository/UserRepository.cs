using CryptoWallet.WalletAPI.DbContexts;
using CryptoWallet.WalletAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoWallet.WalletAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User> AddUser(User newUser)
        {
            var userInDb = await _db.Users.FirstOrDefaultAsync(user => user.Id == newUser.Id);

            if(userInDb != null)
                throw new Exception("Такой пользователь уже зарегистрирован");

            _db.Users.Add(newUser);
            _db.SaveChanges();

            return newUser;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(user => user.Id == id);

            if (user == null)
                throw new Exception("Пользователя не существует");

            return user;
        }
    }
}
