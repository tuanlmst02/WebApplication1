using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
	public class UserCred
	{
		[Required]
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
