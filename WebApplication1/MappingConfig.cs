using AutoMapper;
using WebApplication1.Model;
using WebApplication1.Model.Dto;

namespace WebApplication1
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductDto>();
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<User, UserDto>();
                config.CreateMap<UserDto, User>();

            });
            return mappingConfig;
        }
    }
}
