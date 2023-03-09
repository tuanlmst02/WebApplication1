using WebApplication1.Model;
using WebApplication1.Model.Dto;

namespace WebApplication1.Repository
{
    public interface IUserRepository
    {
        Task<User> CreateUser(UserDto userDto);

        Task<User> ActiveUser(string linkActive);
    }
}
