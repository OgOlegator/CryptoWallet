using CryptoWallet.WalletAPI.Models;
using CryptoWallet.WalletAPI.Models.Dto;
using CryptoWallet.WalletAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWallet.WalletAPI.Controllers
{
    //API для работы с учетными данными пользователей
    [ApiController]
    [Route("api/account")]
    public class AccountDataController : ControllerBase
    {
        private readonly ITransactHistoryRepository _historyRepository;
        private readonly IUserBalanceRepository _balanceRepository;
        private readonly IUserRepository _userRepository;
        protected ResponseDto _response;

        public AccountDataController(ITransactHistoryRepository historyRepository, IUserBalanceRepository balanceRepository, 
            IUserRepository userRepository)
        {
            _historyRepository = historyRepository;
            _balanceRepository = balanceRepository;
            _userRepository = userRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> GetUserInformation(string id)
        {
            var result = new AccountDataResultDto();

            try
            {
                var user = await _userRepository.GetById(int.Parse(id));
                var userBalance = await _balanceRepository.GetUserBalance(int.Parse(id));

                result.User = user;
                result.UserBalance = userBalance;

                _response.Result = result;
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
        public async Task<ResponseDto> AddNewUser([FromBody] User user)
        {
            try
            {
                _response.Result = await _userRepository.AddUser(user);
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
