using CryptoWallet.WalletAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoWallet.WalletAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<UserBalance> UserBalances { get; set; }

        public DbSet<TransactionHistory> History { get; set; }

    }
}
