using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model.Dto
{
	public class ProductDto
	{
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
