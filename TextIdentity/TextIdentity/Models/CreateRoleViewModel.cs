using System.ComponentModel.DataAnnotations;

namespace TextIdentity.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name ="角色名")]
        public string RoleName { get; set; }
    }
}
