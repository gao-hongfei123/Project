using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys
{
    public class StudentLabComplete:BaseEntity
    {
        [ForeignKey(nameof(Student))]
        public Guid studentId { get; set; }
        public Student Student { get; set; }
        [ForeignKey(nameof(Class))]
        public Guid ClassId { get; set; }
        public Class Class { get; set; }
        public DateTime Time { get; set; }
        public int CompletePercent { get; set; }


    }

}
