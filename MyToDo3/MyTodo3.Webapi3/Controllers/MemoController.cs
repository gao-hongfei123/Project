using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTodo3.Webapi3.Context;
using MyTodo3.Webapi3.Service;
using Todo3.Wpf.Shared;
using Todo3.Wpf.Shared.Dtos;

namespace MyTodo3.Webapi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoController : ControllerBase
    {
        private readonly IMemoService service;

        public MemoController(IMemoService service)
        {
            this.service = service;
        }


        [HttpGet]
        [Route("GetSingle")]
        public async Task<ApiResponse> GetAsync(int id) => await service.GetAsync(id);

        [HttpGet]
        [Route("GetAll")]
        public async Task<ApiResponse> GetAllAsync([FromQuery] QueryParameter parameter ) => await service.GetAllAsync(parameter);

        [HttpPost]
        [Route("Add")]
        public async Task<ApiResponse> AddAsync(MemoDto todo) => await service.AddAsync(todo);
        

        [HttpDelete]
        [Route("delete")]
        public async Task<ApiResponse> DeleteAsync(int id) => await service.DeleteAsync(id);

        [HttpPost]
        [Route("Update")]
        public async Task<ApiResponse> UpdateAsync(MemoDto todo ) => await service.UpdateAsync(todo);
    }
}
