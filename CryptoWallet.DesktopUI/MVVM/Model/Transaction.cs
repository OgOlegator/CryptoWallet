using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static CryptoWallet.DesktopUI.SD;

namespace CryptoWallet.DesktopUI.MVVM.Model
{
    public class Transaction
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
