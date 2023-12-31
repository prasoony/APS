using Aps.services.AuthApi.Model.Dto;
using AuthApi.Models.Dto;
using AuthApi.Services.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
	[Route("api/Auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{


		private readonly IAuthService _authService;
		private readonly ResponseDto _responseDto;

        public AuthController( IAuthService authService )
        {
			_authService = authService;
			_responseDto = new();

            
        }


        [HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
		{
			var errorMessage = await _authService.Register(model);
			if (!string.IsNullOrEmpty(errorMessage))
			{
				_responseDto.Sucsess = false;
				_responseDto.Message = errorMessage;
				return BadRequest(_responseDto);
			}
			
			return Ok(_responseDto);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
		{

			var loginResponse = await _authService.Login(model);
			if (loginResponse.user == null)
			{
				_responseDto.Sucsess = false;
				_responseDto.Message = " UserName Or Password is incorrect";
				return BadRequest(_responseDto);
			}
			
				_responseDto.Result = loginResponse; 
				return Ok(_responseDto);
			
		}

		[HttpPost("AssignRole")]
		public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
		{

			var AssignRoleSuccessfull = await _authService.AssignRole(model.Email ,model.Role.ToUpper());
			if (!AssignRoleSuccessfull)
			{
				_responseDto.Sucsess = false;
				_responseDto.Message = " Error encounter";
				return BadRequest(_responseDto);
			}

			
			return Ok(_responseDto);

		}
	}
}
