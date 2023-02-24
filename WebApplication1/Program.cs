using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApplication1;
using WebApplication1.DbContexts;
using WebApplication1.Repository;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(swagger =>
{
	// To Enable authorization using Swagger (JWT)  DK Cac service vao trong pipeline 
	swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",

		In = ParameterLocation.Header,
		Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
	});
	swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						  new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
								{
									Type = ReferenceType.SecurityScheme,
									Id = "Bearer"
								}
							},
							new string[] {}
					}
				});
});

builder.Services.AddAuthentication(option =>
{
	option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = false,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["Jwt:Issuer"],
		ValidAudience = "Tuan Test",
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])) //Configuration["JwtToken:SecretKey"]  
	};
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProductRepository, ProductRepository>();


//builder.Services.AddCors(options =>
//{
//	options.AddDefaultPolicy(policy =>
//	{
//		policy.WithOrigins("https://localhost:7225/").AllowAnyHeader().AllowAnyMethod();
//	});
//});
//builder.Services.AddCors(options =>
//{
//	options.AddPolicy(name: MyAllowSpecificOrigins,
//					  policy =>
//					  {
//						  policy.WithOrigins("https://localhost:7225/").AllowAnyHeader().AllowAnyMethod();
//					  });
//});
builder.Services.AddCors(c =>
{
	c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseAuthentication(); // Phục hồi thông tin đăng nhập (xác thực)
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//Use CORS
app.UseCors(options => options.AllowAnyOrigin());

app.UseAuthorization(); // 

app.MapControllers();
app.Run();
