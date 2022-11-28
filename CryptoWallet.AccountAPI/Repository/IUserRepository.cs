using CryptoWallet.WalletAPI.Models;

namespace CryptoWallet.WalletAPI.Repository
{
    public interface IUserRepository
    {

        Task<User> GetById(int id);

        Task<User> AddUser(User newUser);

    }
}
