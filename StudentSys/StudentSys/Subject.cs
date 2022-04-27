using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys
{
    public class Subject:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [ForeignKey(nameof(Grade))]
        public Guid GradeId { get; set; }
        public Grade Grade { get; set; }
    }
}
