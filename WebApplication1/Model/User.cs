using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
	public class User
    {
        [Required]
        public string Userid { get; set; } = null!;
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public bool IsActive { get; set; } = false;
        public string? LinkActive { get; set; }
    }
}
