using AutoMapper;
using System.Net;
using System.Net.Mail;
using System.Text;
using WebApplication1.DbContexts;
using WebApplication1.Model;
using WebApplication1.Model.Dto;
using WebApplication1.Utility;

namespace WebApplication1.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _db;
		private IMapper _mapper;
		private IConfiguration _config;

		public UserRepository(ApplicationDbContext db, IMapper mapper, IConfiguration config)
		{
			_db = db;
			_mapper = mapper;
			_config = config;
		}

		public async Task<User> ActiveUser(string linkActive)
		{
			var userActive = _db.Users.Where(item => item.LinkActive == String.Format("Active?Id=" + linkActive) && item.IsActive == false).FirstOrDefault();
	
			if (userActive != null)
			{
				userActive.IsActive = true;
				_db.Users.Update(userActive);
				await _db.SaveChangesAsync();
			}

			return userActive;
		}

		public async Task<User> CreateUser(UserDto userDto)
		{

			var register = _mapper.Map<User>(userDto);

			register.Userid = Guid.NewGuid().ToString();
			register.Role = "user";
			register.IsActive = false;
			register.LinkActive = $"Active?Id={register.Userid}";

			_db.Users.Add(register);
			await _db.SaveChangesAsync();
			SendMailActive(register.Email, register.LinkActive);
			return register;
		}

		private void SendMailActive(string email, string linkAct)
		{
			var fromAddress = new MailAddress("tuanlmpd@gmail.com", "Tuan Le");
			var toAddress = new MailAddress("lmtuan@cmcglobal.vn", "Le Test");
			const string fromPassword = "aehsnkklpkfbbims";
			const string subject = "Hello New Member !!!";

			var smtp = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
			};
			using (var message = new MailMessage(fromAddress, toAddress)
			{
				Subject = subject,
				Body = "Please click " + _config["Jwt:Active"] + linkAct
			})
			{
				smtp.Send(message);
			}
		}
	}
}
