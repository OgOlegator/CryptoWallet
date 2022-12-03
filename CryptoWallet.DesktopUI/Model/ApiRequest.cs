using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.DesktopUI.Model
{
    public class ApiRequest
    {

        public SD.APIType APIType { get; set; } = SD.APIType.GET;

        public string Url { get; set; }

        public object Data { get; set; }

    }
}
