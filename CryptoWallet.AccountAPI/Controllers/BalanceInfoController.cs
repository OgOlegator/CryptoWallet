using CryptoWallet.WalletAPI.Models.Dto;
using CryptoWallet.WalletAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWallet.WalletAPI.Controllers
{
    [Route("api/balance")]
    [ApiController]
    public class BalanceInfoController : ControllerBase
    {
        private readonly IUserBalanceRepository _balanceRepository;
        protected ResponseDto _response;

        public BalanceInfoController(IUserBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        [Route("{id}")]
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
        [Route("{id} {coin}")]
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
    }
}
