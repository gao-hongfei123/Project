using Todo3.Wpf.Shared;
using Todo3.Wpf.Shared.Dtos;

namespace MyTodo3.Webapi3.Service
{
    public interface IUserService
    {
        public Task<ApiResponse> Login(string account, string password);

        public Task<ApiResponse> Register(UserDto user);
    }
}
