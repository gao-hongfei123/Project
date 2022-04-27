using StudentSys.BLL;
using StudentSys.WebApi.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace StudentSys.WebApi.Controllers
{
    public class UserController : ApiController
    {
        /*
         /*
            1.ef引用并设置链接字符串
            2.JWT引用
            3.Attribute过滤，校验登录的合法性
            4.每个控制器进行跨域
            5.为Action编写viewModel验证提交的数据的合法性
            6.为返回的结果编写一个ResponseData处理统一返回的数据
         
         */

        public async Task<IHttpActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (EmployeeManager.Login(mail:model.LoginName,model.PassWord,out Guid userid))
                {
                    //登录成功
                }
                else { 
                    //密码有误
                }
            }
            return this.NotFound();
        }
    }
}
