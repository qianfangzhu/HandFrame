using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hand.Model;
using System.Data.Entity;

namespace Hand.Business
{
    public class Employee
    {


        /// <summary>
        /// 朱乾方
        /// 2017-08-23
        /// 根据用户名和密码查询员工
        /// </summary>
        public bool QueryEmployee(int empNo)
        {
            using (var db = new testFrameEntities())
            {
                var test = from a in db.employee
                           where a.emp_No == empNo
                           select a;
                foreach (var value in test)
                {
                    if (value.emp_No > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
