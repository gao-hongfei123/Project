using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    public class EmployeeTypeService:BaseService<EmployeeType>
    {
        public EmployeeTypeService() : base(new StudentContext())
        { 
        
        }
    }
}
