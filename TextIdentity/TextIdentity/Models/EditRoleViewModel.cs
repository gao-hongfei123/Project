using System.ComponentModel.DataAnnotations;

namespace TextIdentity.Models
{
    public class EditRoleViewModel
    {
        [Display(Name ="角色Id")]
        public string Id { get; set; }
        [Required]
        [Display(Name ="角色名称")]
        public string RoleName { get; set; }
        public List<string> Users  { get; set; }
    }
}
