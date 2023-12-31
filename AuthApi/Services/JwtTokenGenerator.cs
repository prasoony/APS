﻿using AuthApi.Models;
using AuthApi.Services.Iservice;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthApi.Services
{
	public class JwtTokenGenerator : IJwtTokenGenerator
	{
		private readonly JwtOptions _jwtOptions;

        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }
        public string GenerateToken(ApplicationUser applicationUser)
		{

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
			var claimslist = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Email,applicationUser.Email),
				new Claim(JwtRegisteredClaimNames.Sub,applicationUser.Id),
				new Claim(JwtRegisteredClaimNames.Name,applicationUser.UserName)
			};
			var tokenDescriptoe = new SecurityTokenDescriptor
			{
				Audience = _jwtOptions.Audience,
				Issuer = _jwtOptions.Issuer,
				Subject = new ClaimsIdentity(claimslist),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token= tokenHandler.CreateToken(tokenDescriptoe);
			return tokenHandler.WriteToken(token);
		}
	}
}
