using Aps.services.AuthApi.Data;
using AuthApi.Models;
using AuthApi.Models.Dto;
using AuthApi.Services.Iservice;
using Microsoft.AspNetCore.Identity;

namespace AuthApi.Services
{
	public class Authservice : IAuthService
	{

		private readonly AppDbcontext _appDbcontext;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IJwtTokenGenerator _jwtTokenGenerator;
		private readonly RoleManager<IdentityRole> _roleManager;
		

        public Authservice( AppDbcontext db ,UserManager<ApplicationUser> userManager,IJwtTokenGenerator jwtTokenGenerator , RoleManager<IdentityRole> roleManager )
        {
             
			_appDbcontext = db;
			_userManager = userManager;
			_jwtTokenGenerator = jwtTokenGenerator;
			_roleManager = roleManager;
		
        }

		public async Task<bool> AssignRole(string Email, string roleName)
		{
			var User = _appDbcontext.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == Email.ToLower());
		    if( User != null )
			{
				if(!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
				{
					_roleManager.CreateAsync( new IdentityRole(roleName) ).GetAwaiter().GetResult();

				}
				await _userManager.AddToRoleAsync(User, roleName);
				return true;
			}
			return false;
		}

		public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
		{
			var User = _appDbcontext.ApplicationUsers.FirstOrDefault(u=> u.UserName.ToLower()== loginRequestDto.UserName.ToLower());
			bool isValid = await _userManager.CheckPasswordAsync(User, loginRequestDto.Password);
			if(User==null || isValid== false)
			{
				return new LoginResponseDto()
				{
					user = null,
					token = ""
				};
			

			}
			var token =_jwtTokenGenerator.GenerateToken(User);

			UserDto userDto = new UserDto()
			{
				Email = User.Email,
				Name = User.Name,
				ID = User.Id,
				Phonenumber = User.PhoneNumber

			};
			LoginResponseDto loginResponseDto = new LoginResponseDto()
			{
				user = userDto,
				token = token
			};
			return  loginResponseDto;
		}

		public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
		{
			ApplicationUser user = new ApplicationUser()
			{
				UserName = registrationRequestDto.Email,
				Email = registrationRequestDto.Email,
				NormalizedEmail = registrationRequestDto.Email,
				Name = registrationRequestDto.Name,
				PhoneNumber = registrationRequestDto.Phonenumber
			};
			try
			{
				var result= await _userManager.CreateAsync(user ,registrationRequestDto.Password);
				if(result.Succeeded) 
				{
					var userToReturn = _appDbcontext.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);
					UserDto userDto = new UserDto()
					{
						Email = userToReturn.Email,
						Name = userToReturn.Name,
						ID = userToReturn.Id,
						Phonenumber = userToReturn.PhoneNumber

					};
					return "";
				}
				else
				{
					return result.Errors.FirstOrDefault().Description;
				}
			}
			catch (Exception ex)
			{
				
			}
			return "Error Acccured";
		}
	}
}
