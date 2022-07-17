using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys
{
    public class StudentTalked:BaseEntity
    {
        [ForeignKey(nameof(Student))]
        public Guid studentId { get; set; }
        public Student Student { get; set; }
        [ForeignKey(nameof(Class))]
        public Guid ClassId { get; set; }
        public Class Class { get; set; }
        public string Content { get; set; }
        public bool IsDone { get; set; }
        public string Result { get; set; }

    }
}
