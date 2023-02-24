﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
	public class ProductDto
	{
		[Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
