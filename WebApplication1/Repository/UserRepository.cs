using AutoMapper;
using System.Net;
using System.Net.Mail;
using System.Text;
using WebApplication1.DbContexts;
using WebApplication1.Model;
using WebApplication1.Model.Dto;

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
        public async Task<User> CreateUpdateUser(UserDto userDto)
        {

            var register = _mapper.Map<User>(userDto);

            register.Userid = Guid.NewGuid().ToString();
            register.Role = "user";
            register.IsActive = false;

            _db.Users.Add(register);
            await _db.SaveChangesAsync();
            SendMailActive(register.Email);
            return register;
        }

        private void SendMailActive(string sEmail)
        {
            var fromAddress = new MailAddress("tuanlmpd@gmail.com", "Tuan Le");
            var toAddress = new MailAddress("lmtuan@cmcglobal.vn", "Le Test");
            const string fromPassword = "mylove42@";
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
                Body = _config["Jwt:Issuer"]
        })
            {
                smtp.Send(message);
            }
        }
    }
}
