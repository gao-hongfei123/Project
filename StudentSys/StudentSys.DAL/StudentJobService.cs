using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    public class StudentJobService:BaseService<StudentJob>
    {
        public StudentJobService() : base(new StudentContext())
        { 
        
        }
    }
}
