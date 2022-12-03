using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CryptoWallet.DesktopUI.Model
{
    public class UserBalanceDto
    {

        public int UserId { get; set; }

        public string Coin { get; set; }

        public decimal Count { get; set; }

        public object User { get; set; }    //Не используется

    }
}
