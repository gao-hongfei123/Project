using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSys.WebApi.Models.User
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(maximumLength:40,MinimumLength =5)]
        [EmailAddress]
        public string LoginName { get; set; }
        [Required]
        [StringLength(maximumLength:40,MinimumLength =6)]
        public string PassWord{ get; set; }   

    }
}