using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys
{
    public class Student:BaseEntity
    {
        [Required]//不许为空
        public string Name { get; set; }
        [Required]
        public string Sex { get; set; }
        public DateTime BornTime { get; set; }
        public string Phone { get; set; }
        public string QQ { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        [ForeignKey(nameof(Class))]//引入外键
        public Guid? ClassId { get; set; }//允许为空
        public Class Class { get; set; }

    }
}
