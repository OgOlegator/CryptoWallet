using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoWallet.WalletAPI.Models
{
    public enum ResultTransaction
    {
        Completed,
        Error
    }

    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public int SenderId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public int RecipientId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Coin { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,12)")]
        public decimal Count { get; set; }

        public DateTime Time { get; set; }

        public ResultTransaction Result { get; set; }
        
    }
}
