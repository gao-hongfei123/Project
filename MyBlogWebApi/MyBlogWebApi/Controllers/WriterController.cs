
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IRespository;
using MyBlog.Model;
using MyBlog.Model.DTO;
using MyBlogWebApi.Utility;
using MyBlogWebApi.Utility.Md5;

namespace MyBlogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private readonly WriterIRespository _writerResponsitory;
        private readonly IMapper _mapper;
        public WriterController(WriterIRespository writerIRespository,IMapper mapper)
        {
            _writerResponsitory = writerIRespository;
            _mapper = mapper;
        }

        //增
        [HttpPost("create")]
        public async Task<ApiResult> Create(string name,string userName,string pwd)
        {
            Writer writer = new Writer
            {
                Name = name,
                UserName = userName,
                UserPwd = Md5Helper.MD5Encrypt32(pwd)
            };
            var model = await _writerResponsitory.FindAsync(c => c.UserName == userName);
            if (model != null) return ApiResultHelper.Error("账号已经存在");
            var flag = await _writerResponsitory.CreateAsync(writer);
            return flag == true ? ApiResultHelper.Success("创建成功") : ApiResultHelper.Error("创建失败");


        }
        //删
        //改
        //查:使用automapper
        [AllowAnonymous]
        [HttpGet("get")]
        public async Task<ApiResult> find(int id)
        {
            var writer =  await _writerResponsitory.FindAsync(id);
            var writerDto = _mapper.Map<WriterDto>(writer);
            return ApiResultHelper.Success(writerDto);
        }
    }
}
