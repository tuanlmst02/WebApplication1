using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

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

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Shiba Inu",
                Price = 1,
                Description = "Dog",
                ImageUrl = "",
                CategoryName = "Pet",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Dogger Coin",
                Price = 12,
                Description = "Dog",
                ImageUrl = "",
                CategoryName = "Pet",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Aslaska",
                Price = 23,
                Description = "Dog",
                ImageUrl = "",
                CategoryName = "Pet",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Bug France",
                Price = 30,
                Description = "Dog",
                ImageUrl = "",
                CategoryName = "Pet",
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Userid = Guid.NewGuid().ToString(),
                Name = "Le Minh Tuan",
                Password = "123",
                Email = "lmtuan@gmail.com",
                Role = "admin",

            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Userid = Guid.NewGuid().ToString(),
                Name = "Nguyen Van A",
                Password = "123",
                Email = "nva@gmail.com",
                Role = "user",
            });
        }
    }
}