using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    public class ScoreService:BaseService<Score>
    {
        public ScoreService() : base(new StudentContext())
        {
            
        }
    }
}
