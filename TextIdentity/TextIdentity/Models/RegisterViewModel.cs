using System.ComponentModel.DataAnnotations;

namespace TextIdentity.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="用户名")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name ="邮箱地址")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="密码")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="密码与确认密码不一致")]
        [Display(Name ="确认密码")]
        public string ConfirmPassword { get; set; }
    }
}
