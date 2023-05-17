using mvcEducation.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEdu.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //로그인 기능
        public ActionResult CheckLogin()
        {
            return View();
        }

        // model = request/response 역할
        public ActionResult SampleLogin(AccountModel request)
        {

            return View();
        }
    }
}