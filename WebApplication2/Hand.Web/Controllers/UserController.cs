﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hand.Business;
using Hand.Model;

namespace Hand.Web.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// 朱乾方
        /// 20170824
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        /// <summary>
        /// 朱乾方
        /// 20170824
        /// 首页页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            return View();
        }

        ///<Summary>
        /// 
        /// 
        /// </Summary>
        /// <returns></returns>
        public int LoginConfirm()
        {
            int empNo = int.Parse(Request["empNo"]);
            string pwd = Request["pwd"];
            Employee e = new Employee();
            if (e.QueryEmployee(empNo, pwd))
            {
                Response.Cookies["empNo"].Value = empNo.ToString();
                Response.Cookies["empNo"].Expires = DateTime.Now.AddDays(1);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public ActionResult GetEmp()
        {
            Employee emp = new Employee();
            var userInfo = emp.GetEmp();
            return Json(userInfo, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public string AddEmp(int? empId, employee emp)
        {
            string msg;
            Employee employee = new Employee();
            if (empId > 0)
            {
                employee.EditEmp(empId, emp);
                msg = "修改成功！";
            }
            else
            {
                employee.AddEmp(emp);
                msg = "添加成功！";
            }
            return msg;
        }
    }
}