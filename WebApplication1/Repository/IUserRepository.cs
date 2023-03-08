using WebApplication1.Model;
using WebApplication1.Model.Dto;

namespace WebApplication1.Repository
{
    public interface IUserRepository
    {
        Task<User> CreateUpdateUser(UserDto userDto);

    }
}
