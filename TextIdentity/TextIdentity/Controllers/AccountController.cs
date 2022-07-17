using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TextIdentity.Models;

namespace TextIdentity.Controllers
{
    
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> _userManager,SignInManager<IdentityUser> _signInManager)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
        }

        [HttpGet]
        public IActionResult register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {  
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = registerViewModel.UserName,
                   Email = registerViewModel.Email,
                   
                   
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    return Content("执行成功");
                }
                else {
                    return Content("执行失败");
                }

            }
            return Content("数据验证失败");
            
        }

    }
}
