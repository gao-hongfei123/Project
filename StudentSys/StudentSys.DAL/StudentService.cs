using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    public class StudentService : BaseService<Student>
    {
        public StudentService(StudentContext db) : base(db)
        {
        }
    }
}
