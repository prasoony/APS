using AuthApi.Models;

namespace AuthApi.Services.Iservice
{
	public interface IJwtTokenGenerator
	{

		string GenerateToken(ApplicationUser applicationUser);
	}
}
