using CryptoWallet.WalletAPI.Models.Dto;
using CryptoWallet.WalletAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWallet.WalletAPI.Controllers
{
    //API для получения информации о балансе пользователя
    [Route("api/balance")]
    [ApiController]
    public class BalanceInfoController : ControllerBase
    {
        private readonly IUserBalanceRepository _balanceRepository;
        protected ResponseDto _response;

        //todo добавить пополнение баланса
        public BalanceInfoController(IUserBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ResponseDto> GetBalance(string userId)
        {
            try
            {
                _response.Result = await _balanceRepository.GetUserBalance(int.Parse(userId));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.DisplayMessage = ex.Message;
            }

            return _response;
        }

        [HttpGet]
        [Route("{userId} {coin}")]
        public async Task<ResponseDto> GetBalanceByCoin(string userId, string coin)
        {
            try
            {
                _response.Result = await _balanceRepository.GetBalanceByCoin(int.Parse(userId), coin);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.DisplayMessage = ex.Message;
            }

            return _response;
        }

        [HttpPut]
        [Route("{userId} {coin} {count}")]
        public async Task<ResponseDto> IncreaseBalance(string userId, string coin, string count)
        {
            try
            {
                var userBalance = await _balanceRepository.IncreaseBalance(int.Parse(userId), coin, decimal.Parse(count));
                _response.Result = userBalance;
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
