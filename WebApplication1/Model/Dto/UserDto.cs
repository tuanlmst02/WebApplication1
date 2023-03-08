using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model.Dto
{
    public class UserDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
