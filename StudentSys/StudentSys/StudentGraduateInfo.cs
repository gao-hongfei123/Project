using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys
{
    public class StudentGraduateInfo:BaseEntity
    {
        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public DateTime InTime { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
