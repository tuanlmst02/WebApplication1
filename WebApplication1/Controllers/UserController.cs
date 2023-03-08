using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.DbContexts;
using WebApplication1.Model;
using WebApplication1.Model.Dto;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		protected Response _response;
		private IConfiguration _config;
		private readonly ApplicationDbContext _db;
		private IUserRepository _userRepository; 

		public UserController(IConfiguration config, ApplicationDbContext db, IUserRepository userRepository)
		{
			_response = new Response();
			_config = config;
			_db = db;
			_userRepository = userRepository;
		}

		//[HttpPost]
		//[AllowAnonymous]
		//[Route("Login")]
		//public async Task<object> Login(Login login)
		//{
		//	if (login == null)
		//	{
		//		_response.IsSuccess = false;
		//		_response.ErrorMessages = new List<string>() { "Invalid account request" };
		//		return Unauthorized(_response);
		//	}

		//	if (login.UserName == "admin" && login.Password == "@123")
		//	{
		//		var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
		//		var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
		//		//var claims = new[] {
		//		//				new Claim("Username", "tuanlm"),
		//		//				new Claim("Email", "tuanlm@gmail.com"),
		//		//				new Claim("Nickname", "tunn"),};
		//		//var token = new JwtSecurityToken(_config["Jwt:Issuer"],
		//		//  _config["Jwt:Issuer"],
		//		//  null,
		//		//  expires: DateTime.Now.AddMinutes(120),
		//		//  signingCredentials: credentials);


		//		var claims = new[] {
		//						new Claim("Username", "tuanlm"),
		//						new Claim("Email", "tuanlm@gmail.com"),
		//						new Claim("Nickname", "tunn"),};

		//		var token_New = new JwtSecurityToken(issuer: _config["Jwt:Issuer"],
		//											 audience: "Tuan Test",
		//											 claims: claims,
		//											 expires: DateTime.Now.AddMinutes(120),
		//											 signingCredentials: credentials);

		//		var tokenString = new JwtSecurityTokenHandler().WriteToken(token_New);
		//		_response.Result = tokenString;
		//		return Ok(_response);
		//	}
		//	else
		//	{
		//		_response.IsSuccess = false;
		//		_response.ErrorMessages = new List<string>() { "Invalid User" };
		//		return Unauthorized(_response);
		//	}
		//}
		[HttpPost]
		[Route("Register")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> Register([FromBody]UserDto userDto)
        {
            try
            {
				var register = await _userRepository.CreateUpdateUser(userDto);
				_response.Result = register;
				_response.DisplayMessage = "Check mail to active account";
				_response.IsSuccess = true;
            }
            catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string> { ex.Message };
				return BadRequest(_response);
			}
			return Ok(_response);
        }

		[HttpPost]
		[AllowAnonymous]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] UserCred userCred)
		{
			var user = await this._db.Users.FirstOrDefaultAsync(item => item.Email == userCred.Email && item.Password == userCred.Password);
			if (user == null)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { "Invalid account request" };
				return Unauthorized(_response);
			}

			/// Generate Token
			var tokenhandler = new JwtSecurityTokenHandler();
			var tokenkey = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

			var claims = new[] {
								new Claim(ClaimTypes.Name, user.Email),
								new Claim(ClaimTypes.Role, user.Role),};

			var token = new JwtSecurityToken(issuer: _config["Jwt:Issuer"],
												 audience: "Tuan Test",
												 claims: claims,
												 expires: DateTime.Now.AddMinutes(120),
												 signingCredentials: new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256));

			var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
			_response.Result = tokenString;

			return Ok(_response);
		}


	}
}
