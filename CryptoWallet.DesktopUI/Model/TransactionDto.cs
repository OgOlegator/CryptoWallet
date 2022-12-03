using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CryptoWallet.DesktopUI.SD;

namespace CryptoWallet.DesktopUI.Model
{
    public class TransactionDto
    {

        public int Id { get; set; }

        public int SenderId { get; set; }

        public int RecipientId { get; set; }

        public string Coin { get; set; }

        public decimal Count { get; set; }

        public DateTime Time { get; set; }

        public ResultTransaction Result { get; set; }

    }
}
