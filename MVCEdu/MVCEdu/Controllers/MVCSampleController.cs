using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcEducation.Contract.Models;
using mvcEducation.Rep;

namespace MVCEdu.Controllers
{
    public class MVCSampleController : Controller
    {
        // GET: MVCSample
        public ActionResult Index()
        {
            return View();
        }

        //예제1) 데이터 입력
        public ActionResult Sample1(AccountModel request)
        {
            // 결과를 반환하는 객체 생성
            AccountModel response = new AccountModel();

            // repository 객체 생성 -> DB의 결과를 받는 객체. DB 연결 후 SP 호출
            Account req = new Account();
            bool chkResult = req.CheckLogin(request);

            if (chkResult)
            {
                response.accountEntity.ID = request.accountEntity.ID;
                response.accountEntity.Password = request.accountEntity.Password;

                // session에 데이터 담기
                Session["ID"] = response.accountEntity.ID;
                Session["PW"] = response.accountEntity.Password;
            }

            return View(response);
        }

        //예제2) ViewBag, ViewData, TempData
        public ActionResult Sample2(AccountModel request)
        {
            List<string> Students = new List<string>(0);
            Students.Add("조수아");
            Students.Add("오행송");
            Students.Add("김한비");

            //ViewBag: Dinamic object 이므로 자동으로 변수 자료형을 유추해 형변환이 필요없음
            ViewBag.Students = Students;

            //ViewData: Dictionary Collection 이므로 값이 객체로 나와 형변환이 필요함
            ViewData["Students"] = Students;

            //TempData: ViewData와 동일한 특성이라서 값이 세션에 임시저장되지만 리다이렉션이 발생해도 데이터 유지됨
            TempData["Students"] = Students;

            return View(request);
        }

        //예제3) Partial View
        public ActionResult Sample3()
        {
            //결과 반환 객체
            DetailModel response = new DetailModel();

            // DB 관련 반환
            Comment rep = new Comment();

            response.commentModel.commentEntities = rep.CommentList();
            return View(response);
        }
    }
}