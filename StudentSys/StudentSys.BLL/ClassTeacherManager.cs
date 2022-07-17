using StudentSys.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.BLL
{
    public class ClassTeacherManager
    {
        /// <summary>
        /// 创建班级==新增
        /// </summary>
        /// <param name="claName"></param>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public static async Task CreateClass(string claName, Guid gradeId)
        {
            using (var clsSvc = new ClasstService())
            {
                await clsSvc.CreateAsync(new Class()
                { 
                    GradeId = gradeId,
                    Name = claName
                });
            }
        }

        /// <summary>
        /// 换班级==修改
        /// </summary>
        /// <param name="claId"></param>
        /// <param name="claName"></param>
        /// <returns></returns>
        public static async Task ChangeClassName(Guid claId, string claName)
        {
            using (var clsSvc = new ClasstService())
            {
                await clsSvc.EditAsync(new Class() { 
                    
                });
            }
        }
        /// <summary>
        /// 升学==查询，修改
        /// </summary>
        /// <returns></returns>
        public static async Task LevelUpClass(Guid clsId)
        {
            using (var clsSvc = new ClasstService())
            {
                var cls = await clsSvc.GetOne(clsId);
                using (var gradeSvc = new GradeService())
                { 
                    //
                }
            }
        }
        /// <summary>
        /// 毕业
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task ClassGraduation(Guid id)
        { 
        
        }
        
    }
}
