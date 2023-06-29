using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTodo3.Webapi3.Service;
using Todo3.Wpf.Shared;
using Todo3.Wpf.Shared.Dtos;

namespace MyTodo3.Webapi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService service;

        public LoginController(IUserService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("Login")]
        public Task<ApiResponse> Login(string account,string password)=>service.Login(account,password);

        [HttpPost]
        [Route("Register")]
        public Task<ApiResponse> Register(UserDto user)=>service.Register(user);
    }
}
