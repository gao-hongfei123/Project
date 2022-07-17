using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys
{
    public class StudentDoc:BaseEntity
    {
        [ForeignKey(nameof(Student))]//外键映射到学生表
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
    }
}
