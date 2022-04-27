using StudentSys.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.BLL
{
    public class EmployeeManager

    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="pwd"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Login(string mail, string pwd, out Guid id)
        {
            using (var empSvc = new EmployeeService())
            {
                var emp = empSvc.GetAll().FirstOrDefault();
                if (emp == null)
                {
                    id = Guid.Empty;
                    return false;
                }
                else
                {
                    id = emp.Id;
                    return true;
                }
            }

        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <param name="guid"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static async Task CreateEmployee(string email, string pwd, Guid TypeId, string phone = null)
        {
            using (var empSvc = new EmployeeService())
            {
                await empSvc.CreateAsync(new Employee()
                {
                    Email = email,
                    PassWord = pwd,
                    EmployeeTypeId = TypeId,
                    Phone = phone
                });
            }
        }
    }
}
