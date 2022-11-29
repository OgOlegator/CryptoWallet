using CryptoWallet.WalletAPI.Models;
using CryptoWallet.WalletAPI.Models.Dto;
using CryptoWallet.WalletAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWallet.WalletAPI.Controllers
{
    //API для работы с транзакциями
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactHistoryRepository _historyRepository;
        private readonly IUserBalanceRepository _balanceRepository;
        protected ResponseDto _response;

        public TransactionController(ITransactHistoryRepository historyRepository, IUserBalanceRepository balanceRepository)
        {
            _historyRepository = historyRepository;
            _balanceRepository = balanceRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ResponseDto> GetHistory(string userId)
        {
            try
            {
                _response.Result = await _historyRepository.GetHistoryByUserId(int.Parse(userId));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.DisplayMessage = ex.Message;
            }

            return _response;
        }

        [HttpPost]
        [Route("{senderId} {recipientId} {coin} {count}")]
        public async Task<ResponseDto> RunTransaction(string senderId, string recipientId, string coin, string count)
        {
            var transaction = new TransactionHistory
            {
                SenderId = int.Parse(senderId),
                RecipientId = int.Parse(recipientId),
                Coin = coin,
                Count = decimal.Parse(count),
            };

            try
            {
                await _balanceRepository.ChangeBalance(transaction);
                _response.Result = await _historyRepository.AddTransaction(transaction);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.DisplayMessage = ex.Message;
            }

            return _response;
        }

    }
}
