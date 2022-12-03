using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.DesktopUI
{
    public static class SD
    {

        public const string WalletApi = "https://localhost:7002";

        public enum APIType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public enum ResultTransaction
        {
            Completed,
            Error
        }

    }
}
