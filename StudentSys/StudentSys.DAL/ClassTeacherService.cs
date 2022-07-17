using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    public class ClassTeacherService : BaseService<ClassTeacher>
    {
        public ClassTeacherService() : base(new StudentContext())//将数据库上下文传递给父类
        {
        }
    }
}
