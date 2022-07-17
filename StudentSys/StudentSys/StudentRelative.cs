using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys
{
    public class StudentRelative:BaseEntity
    {
        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        [Required]
        public String  Name { get; set; }
        [Required]
        public String  TypeName { get; set; }
        [Required]
        public String Phone  { get; set; }
    }
    
}
