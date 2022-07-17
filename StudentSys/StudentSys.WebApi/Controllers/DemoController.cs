using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentSys.WebApi.Controllers
{
    public class DemoController : ApiController
    {
        // GET api/<controller>
        /*
            1.ef引用并设置链接字符串
            2.JWT引用
            3.Attribute过滤，校验登录的合法性
            4.每个控制器进行跨域
            5.为Action编写viewModel验证提交的数据的合法性
            6.为返回的结果编写一个ResponseData处理统一返回的数据
         
         */
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}