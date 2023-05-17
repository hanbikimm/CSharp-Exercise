using mvcExercise.Contract.Entities;
using mvcExercise.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcExercise.Controllers
{
    public class HtmlHelperController : Controller
    {
        // GET: HtmlHelper
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test(TestModel request)
        {
            //DropDownList 세팅
            List<TextValueItem> subjectList = new List<TextValueItem>();

            subjectList.Add(new TextValueItem() { TextField = "Backend", ValueField = "1" });
            subjectList.Add(new TextValueItem() { TextField = "C#", ValueField = "2" });
            subjectList.Add(new TextValueItem() { TextField = "Frontend", ValueField = "3" });
            subjectList.Add(new TextValueItem() { TextField = "Vue", ValueField = "3" });

            ViewBag.SubjectList = subjectList;


            // request 받아와 response에 담아주기
            TestModel response = new TestModel();
            response.testEntity.ID = request.testEntity.ID;
            response.testEntity.Title = request.testEntity.Title;
            response.testEntity.Subject = request.testEntity.Subject;
            response.testEntity.Description = request.testEntity.Description;
            response.testEntity.Password = request.testEntity.Password;
            response.testEntity.Gender = request.testEntity.Gender;
            response.testEntity.IsSecret = request.testEntity.IsSecret;

            return View(response);
        }
    }
}