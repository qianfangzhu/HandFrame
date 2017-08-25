using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hand.Model;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.ComponentModel;
using Hand.Enum;

namespace Hand.Business
{
    /// <summary>
    /// 人员信息
    /// </summary>
    public class Employee
    {

        public testFrameEntities DbEntities;

        public Employee()
        {
            DbEntities = new testFrameEntities();
        }

        /// <summary>
        /// 朱乾方
        /// 2017-08-23
        /// 根据用户名和密码查询员工
        /// </summary>
        public bool QueryEmployee(int empNo, string pwd)
        {
            using (DbEntities)
            {
                var test = from a in DbEntities.employee
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

        /// <summary>
        /// 朱乾方
        /// 20170824
        /// 获取员工信息
        /// </summary>
        /// <returns></returns>
        public List<EmployeeInfo> GetEmp()
        {
            //var emp = DbEntities.employee.ToList().Select(e => new EmployeeInfo
            //{
            //    EmpNo = e.emp_No,
            //    EmpName = e.emp_name,
            //    EmpEmail = e.emp_email,
            //    EmpDept = e.emp_dept_id,
            //    EmpIsValid = e.emp_isvalid,
            //    EmpJoinTime = Convert.ToDateTime(e.emp_jointime).ToString("yyyy-MM-dd"),
            //    EmpMobile = e.emp_mobile,
            //    EmpResponse = e.emp_role_id,
            //    EmpWorkAddress = e.emp_workaddress
            //}).ToList();
            var empInfo = (from emp in DbEntities.employee.ToList()
                           join dept in DbEntities.Department.ToList() on emp.emp_dept_id equals dept.dept_id
                           join role in DbEntities.Role.ToList() on emp.emp_role_id equals role.role_id
                           select new EmployeeInfo
                           {
                               EmpId = emp.emp_id,
                               EmpNo = emp.emp_No,
                               EmpName = emp.emp_name,
                               EmpMobile = emp.emp_mobile,
                               EmpEmail = emp.emp_email,
                               EmpRoleName = role.role_name,
                               EmpIsValid = EnumHelper.GetDescription((CommonEnum)emp.emp_isvalid.GetHashCode()),
                               EmpWorkAddress = emp.emp_workaddress,
                               EmpJoinTime = Convert.ToDateTime(emp.emp_jointime).ToString("yyyy-MM-dd"),
                               EmpDeptName = dept.dept_name
                           }).ToList();
            return empInfo;
        }

        /// <summary>
        /// 朱乾方
        /// 20170824
        /// 添加员工
        /// </summary>
        /// <returns></returns>
        public bool AddEmp(employee emp)
        {
            try
            {
                employee employee = new employee
                {
                    //emp_No = emp.emp_No,
                    //emp_name = emp.emp_name,
                    //emp_email = emp.emp_email,
                    //emp_mobile = emp.emp_mobile,
                    //emp_role_id = emp.emp_role_id,
                    //emp_workaddress = emp.emp_workaddress,
                    //emp_jointime = emp.emp_jointime,
                    //emp_dept_id = emp.emp_dept_id,
                    //emp_isvalid = 1
                    emp_No = 13951,
                    emp_name = "林佳",
                    emp_email = "jia.lin@hand-china.com",
                    emp_mobile = "13035689452",
                    emp_role_id = 1,
                    emp_workaddress = "上海浦东",
                    emp_jointime = DateTime.Now,
                    emp_dept_id = 1144,
                    emp_isvalid = 1
                };
                DbEntities.employee.Add(employee);
                DbEntities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 朱乾方
        /// 20170824
        /// 编辑
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool EditEmp(int? empId, employee employee)
        {
            if (empId > 0)
            {
                employee emp = DbEntities.employee.FirstOrDefault(e => e.emp_No == empId);//先查找出要修改的对象
                if (emp != null)
                {
                    emp = employee;
                    DbEntities.employee.Attach(emp);
                    DbEntities.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 朱乾方
        /// 20170824
        /// 将人员无效
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public bool DeleteEmp(int? empId)
        {
            if (empId > 0)
            {
                employee emp = DbEntities.employee.FirstOrDefault(e => e.emp_No == empId);//先查找出要修改的对象
                if (emp != null)
                {
                    emp.emp_isvalid = 0;
                    DbEntities.employee.Attach(emp);
                    DbEntities.employee.Remove(emp);
                    DbEntities.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
