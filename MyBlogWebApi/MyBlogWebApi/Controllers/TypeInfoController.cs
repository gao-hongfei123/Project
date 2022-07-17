using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IRespository;
using MyBlog.Model;
using MyBlogWebApi.Utility;

namespace MyBlogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeInfoController : ControllerBase
    {
        private readonly TypeInfoIRespository _typeInfoIRespository1;
        public TypeInfoController(TypeInfoIRespository  typeInfoIRespository)
        {
            _typeInfoIRespository1 = typeInfoIRespository;
        }

        //增
        [HttpPost("create")]
        public async Task<ApiResult> Create(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) return  ApiResultHelper.Error("姓名不能为空");
            var model = new TypeInfo { Name = name };
            var flag = await _typeInfoIRespository1.CreateAsync(model);
            return flag == true ? ApiResultHelper.Error("添加成功") : ApiResultHelper.Error("添加失败");
            
        }
        //删
        [HttpDelete("delete")]
        public async Task<ApiResult> Delete(int id)
        { 
            var flag = await _typeInfoIRespository1.FindAsync(id);
            if (flag == null) return ApiResultHelper.Error("没有查询到");
            var flag2 = await _typeInfoIRespository1.DeleteAsync(id);
            return flag2 == true ? ApiResultHelper.Success("删除成功") : ApiResultHelper.Error("删除失败");
        }
        //改
        [HttpPut("update")]
        public async Task<ApiResult> Update(int id,string name) 
        {
            var type = await _typeInfoIRespository1.FindAsync(id);
            if (type == null) return ApiResultHelper.Error("没有查找到");
            type.Name = name;
            var flag = await _typeInfoIRespository1.UpdateAsync(type);
            return flag == true ? ApiResultHelper.Success("修改成功") : ApiResultHelper.Error("修改失败");
        }
        //查
        [HttpGet("get")]
        public async Task<ApiResult> GetType()
        { 
            var arr = await _typeInfoIRespository1.QueryAsync();
            return ApiResultHelper.Success(arr);
        }
    }
}
