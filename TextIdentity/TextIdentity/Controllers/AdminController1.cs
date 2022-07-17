using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TextIdentity.Models;

namespace TextIdentity.Controllers
{
   
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly UserManager<IdentityUser> _userManager;
        public AdminController(RoleManager<IdentityRole> roleManager,UserManager<IdentityUser> userManager )
        {
            this._rolemanager = roleManager;
            this._userManager = userManager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                { Name = createRoleViewModel.RoleName
            };
                var result = await _rolemanager.CreateAsync(identityRole);
                if(result.Succeeded)
                {
                    return View(createRoleViewModel);
                }
                else {
                    return Content("构建角色失败");
                }
            }
            return View(createRoleViewModel);
        }
        [HttpGet]
        public IActionResult RoleList()
        {
            var result = _rolemanager.Roles;
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        { 
            //查找
            var role = await _rolemanager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound("未找到该角色");
            }
            else {//查找到赋给模型类
                var model = new EditRoleViewModel
                {
                    RoleName = role.Name,
                    Id = role.Id
                };
                //遍历所有用户，判断用户是否在编辑后的角色中,若是则将用户名添加到模型类中的集合中
                var users = _userManager.Users.ToList();
                foreach (var item in users)
                {
                    if (await _userManager.IsInRoleAsync(item, role.Name))
                    {
                        model.Users.Add(item.UserName);
                    }
                }
                return View(model);
            }
            
            
          
            
        }
    }
}
