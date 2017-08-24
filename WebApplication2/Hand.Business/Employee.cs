using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public bool QueryEmployee(int empNo,string pwd)
        {
            using (var db = new testFrameEntities())
            {
                var test = from a in db.employee
                           where a.emp_No == empNo
                           select a;
                foreach (employee value in test)
                {
                    if (value.emp_pwd == pwd)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
