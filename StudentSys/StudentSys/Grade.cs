using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys
{
    public  class Grade:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public int Order { get; set; }//相当于flag，用来标定哪个年级
    }
}
