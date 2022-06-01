using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IRespository;
using MyBlog.Model;
using MyBlogWebApi.Utility;
using SqlSugar;

namespace MyBlogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogNewsController : ControllerBase
    {
        private readonly BlogNewsIRespository _respository;
        private readonly IMapper _mapper;
        public BlogNewsController(BlogNewsIRespository blogNewsIRespository,IMapper mapper)
        {
            _respository = blogNewsIRespository;
            _mapper = mapper;
        }

        [HttpGet("BlogNews")]
        public async Task<ActionResult<List<BlogNews>>> GetBlogNews() {
            var data=await _respository.QueryAsync();
            if (data == null) return  null;
            return data;
        }
        [HttpPost("Create")]
        public async Task<ActionResult<ApiResult>> Create(string title, string content, int typeid)
        {
            BlogNews bn = new BlogNews
            {
                Title = title,
                Content = content,
                TypeId = typeid,
                BrowerCount = 0,
                LikeCount = 0,
                Time = DateTime.Now,
                WriterId = 1
            };
            var model = await _respository.CreateAsync(bn);
            if (!model) return  ApiResultHelper.Error("添加失败");
            return ApiResultHelper.Success("添加成功");
        }
        [HttpDelete]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            var flag = await _respository.DeleteAsync(id);
            if (!flag) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success("删除成功");
        }
        [HttpPut]
        public async Task<ActionResult<ApiResult>> update(int id, string title, string content, int typeId)
        { 
            var entity = await _respository.FindAsync(id);
            if (entity == null)
            { return ApiResultHelper.Error("没有查询到"); }
             else { 
                entity.Title = title;
                entity.Content = content;
                entity.TypeId = typeId;
                entity.BrowerCount = 0;
                entity.LikeCount = 0;
                var flag = await _respository.UpdateAsync(entity);
                if (!flag) return ApiResultHelper.Error("修改失败");
                return ApiResultHelper.Success("修改成功");

            }
            
        }
        [HttpGet("BlogNewsPage")]
        public async Task<ApiResult> GetBlogNewsPage(int page,int size )
        {
            RefAsync<int> total = 0;//不懂
            var blognews =  await _respository.QueryAsync(page,size,total);
            var blognewsDto= _mapper.Map<List<BlogNews>>(blognews);
            return ApiResultHelper.Success(blognewsDto,total);
            
        }
        
    }
}
