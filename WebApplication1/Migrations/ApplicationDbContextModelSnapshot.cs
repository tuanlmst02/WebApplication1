﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.DbContexts;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryName = "Pet",
                            Description = "Dog",
                            ImageUrl = "",
                            Name = "Shiba Inu",
                            Price = 1.0
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryName = "Pet",
                            Description = "Dog",
                            ImageUrl = "",
                            Name = "Dogger Coin",
                            Price = 12.0
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryName = "Pet",
                            Description = "Dog",
                            ImageUrl = "",
                            Name = "Aslaska",
                            Price = 23.0
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryName = "Pet",
                            Description = "Dog",
                            ImageUrl = "",
                            Name = "Bug France",
                            Price = 30.0
                        });
                });

            modelBuilder.Entity("WebApplication1.Model.Role", b =>
                {
                    b.Property<string>("Roleid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Roleid");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WebApplication1.Model.User", b =>
                {
                    b.Property<string>("Userid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Userid");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Userid = "d8bbdb3d-c158-4cde-8690-8b5de17e957b",
                            Email = "lmtuan@gmail.com",
                            IsActive = false,
                            Name = "Le Minh Tuan",
                            Password = "123",
                            Role = "admin"
                        },
                        new
                        {
                            Userid = "e53c0fc8-ab11-433c-b747-7003f60b2db5",
                            Email = "nva@gmail.com",
                            IsActive = false,
                            Name = "Nguyen Van A",
                            Password = "123",
                            Role = "user"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
