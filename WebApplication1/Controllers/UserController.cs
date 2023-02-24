using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Model;
using WebApplication1.Model.Dto;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		protected Response _response;
		private IConfiguration _config;
		public UserController(IConfiguration config)
		{
			_response = new Response();
			_config = config;
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<object> Login(Login login)
		{
			if (login == null)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { "Invalid account request" };
				return Unauthorized(_response);
			}

			if (login.UserName == "admin" && login.Password == "@123")
			{
				var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
				var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
				var claims = new[] {
								new Claim("Username", "tuanlm"),
								new Claim("Email", "tuanlm@gmail.com"),
								new Claim("Nickname", "tunn"),};
				//var token = new JwtSecurityToken(_config["Jwt:Issuer"],
				//  _config["Jwt:Issuer"],
				//  null,
				//  expires: DateTime.Now.AddMinutes(120),
				//  signingCredentials: credentials);

				var token_New = new JwtSecurityToken(issuer: _config["Jwt:Issuer"],
													 audience: "Tuan Test",
													 claims: claims,
													 expires: DateTime.Now.AddMinutes(120),
													 signingCredentials: credentials);

				var tokenString = new JwtSecurityTokenHandler().WriteToken(token_New);
				_response.Result = tokenString;
				return Ok(_response);
			}
			else
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { "Invalid User" };
				return Unauthorized(_response);
			}
		}
	}
}
