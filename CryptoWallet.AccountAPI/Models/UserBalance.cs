using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoWallet.WalletAPI.Models
{
    [PrimaryKey(nameof(Id), nameof(UserId), nameof(Coin))]
    public class UserBalance
    {

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public int UserId { get; set; }

        [Key]
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Coin { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,12)")]
        public decimal Count { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
