using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcExercise.Contract.Entities;
using mvcExercise.Contract.Models;

namespace mvcExercise.Controllers
{
    public class ActionResultController : Controller
    {
        // GET: ActionResult
        public ActionResult Index()
        {
            return View();
        }

        //public ContentResult Content()
        //{
        //    // 1.
        //    ContentResult contentResult = new ContentResult();
        //    contentResult.Content = "MostiSoft 기술 세미나";

        //    // 2.
        //    ContentResult contentResult = new ContentResult();
        //    contentResult.ContentType = "text/html";
        //    contentResult.Content = "<font color='red'>MostiSoft</font> 입니다.";

        //    return contentResult;
        //}

        //public FileStreamResult Content()
        //{
        //    System.IO.FileStream fs = new System.IO.FileStream(@"C:/Users/MOSTI/source/repos/hanbikimm/Board/pictures/v.jpg", System.IO.FileMode.Open);

        //    FileStreamResult fsr = new FileStreamResult(fs, System.Net.Mime.MediaTypeNames.Application.Octet.ToString());
        //    fsr.FileDownloadName = "v.jpg";

        //    return fsr;
        //}

        //public HttpStatusCodeResult Content()
        //{
        //    return new HttpStatusCodeResult(401);
        //}

        // button 형식으로
        //public JavaScriptResult Content()
        //{
        //    string message = "alert('MostiSoft 기술세미나');";
        //    JavaScriptResult jsr = new JavaScriptResult();
        //    jsr.Script = message;

        //    return jsr;
        //}

        public JsonResult Content()
        {
            //LoginEntity login = new LoginEntity();
            //login.ID = "htkim@mostisoft.com";
            //login.Password = "1111";

            LoginModel model = new LoginModel();
            model.loginEntity.ID = "hbkim@mostisoft.com";
            model.loginEntity.Password = "1234";


            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}