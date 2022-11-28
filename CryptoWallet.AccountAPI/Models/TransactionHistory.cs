using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoWallet.WalletAPI.Models
{
    public enum TransactOpearation
    {
        Admission,  //поступление
        Departure   //отправление
    }

    public class TransactionHistory
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

    }
}
