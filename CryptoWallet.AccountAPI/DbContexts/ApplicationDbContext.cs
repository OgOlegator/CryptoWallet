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

        public DbSet<Transaction> History { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Transaction>()
                .Property(e => e.Result)
                .HasConversion(
                    v => v.ToString(),
                    v => (ResultTransaction)Enum.Parse(typeof(ResultTransaction), v));
        }

    }
}
