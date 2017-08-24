using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Login()
        {

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
    }
}