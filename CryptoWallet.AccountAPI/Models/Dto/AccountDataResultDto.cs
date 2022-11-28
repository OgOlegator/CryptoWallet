namespace CryptoWallet.WalletAPI.Models.Dto
{
    public class AccountDataResultDto
    {

        public User User { get; set; }

        public IEnumerable<UserBalance> UserBalance { get; set; }

    }
}
