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
        private readonly IUserRepository _userRepository;
        protected ResponseDto _response;

        public AccountDataController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ResponseDto> GetUserInformation(string userId)
        {
            try
            {
                _response.Result = await _userRepository.GetById(int.Parse(userId));
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
