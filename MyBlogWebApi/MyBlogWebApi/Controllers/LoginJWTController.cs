using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyBlog.IRespository;
using MyBlogWebApi.Utility;
using MyBlogWebApi.Utility.Md5;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyBlogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginJWTController : ControllerBase
    {
        private readonly WriterIRespository _writerIRespository1;
        public LoginJWTController(WriterIRespository writerIRespository)
        {
            _writerIRespository1 = writerIRespository;
        }
        [HttpPost("login")]
        public async Task<ApiResult> Login(string userName,string userPwd)
        {
            //数据校验
            //21232F297A57A5A743894AE4A801FC3
            //21232F297A57A5A743894AE4A801FC3
            //"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJwd2QiOiIyMTIzMkYyOTdBNTdBNUE3NDM4OTRBRTRBODAxRkMzIiwiaWQiOiI0IiwiZXhwIjoxNjUzNjY3MDA4LCJpc3MiOiJodHRwOi8vbG9jb2xob3N0OjcxMTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQ0MzM5In0.D2Ymy9ShPp9Y4TmpMy5kryN90dlqblJLvHGH9AiYfWI"
            var pwd = Md5Helper.MD5Encrypt32(userPwd);
            var flag = await _writerIRespository1.FindAsync(c => c.UserName == userName && c.UserPwd == pwd);
            if (flag == null)
            {//登录失败
                 return ApiResultHelper.Error("用户名或者密码错误");
            }
            else {
                //登录成功
                var claim = new Claim[]{
                            new Claim(ClaimTypes.Name,userName),
                            new Claim("pwd",pwd),
                            new Claim("id",flag.Id.ToString())};
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ghf.303515.096.aaa"));//定义密钥，只有输入密钥之后才能访问
                var token = new JwtSecurityToken(
                                        issuer: "http://locolhost:7119",
                                        audience: "http://localhost:44339",
                                        claims: claim,//将2中的payload添加到taken中
                                        expires: DateTime.Now.AddHours(1),//添加过期时间
                                        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));//添加密钥及算法
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);//按照3中的对象生成token
                return ApiResultHelper.Success(jwtToken);
            }
             


        }
    }
}
