using AuthApi.Models.Dto;

namespace AuthApi.Services.Iservice
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string Email, string roleName);

    }
}
