using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSys;

namespace StudentSys.DAL
{
    public class ClasstService : BaseService<Class>
    {
        public ClasstService() : base(new StudentContext())
        {
        }
    }
}
