using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
using WebApplication1.Model.Dto;

namespace WebApplication1.DbContexts
{
	public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductDto>().HasData(new ProductDto
            {
                ProductId = 1,
                Name = "Shiba Inu",
                Price = 1,
                Description = "Dog",
                ImageUrl = "",
                CategoryName = "Pet",
            });
            modelBuilder.Entity<ProductDto>().HasData(new ProductDto
            {
                ProductId = 2,
                Name = "Dogger Coin",
                Price = 12,
                Description = "Dog",
                ImageUrl = "",
                CategoryName = "Pet",
            });
            modelBuilder.Entity<ProductDto>().HasData(new ProductDto
            {
                ProductId = 3,
                Name = "Aslaska",
                Price = 23,
                Description = "Dog",
                ImageUrl = "",
                CategoryName = "Pet",
            });
            modelBuilder.Entity<ProductDto>().HasData(new ProductDto
            {
                ProductId = 4,
                Name = "Bug France",
                Price = 30,
                Description = "Dog",
                ImageUrl = "",
                CategoryName = "Pet",
            });
        }
    }
}