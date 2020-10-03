using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JasonTest.Models;

namespace JasonTest.Controllers
{
    public class HomeController : Controller
    {
        StudentEntities db = new StudentEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult StudentCreate()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SelectStudent()
        {
            return View();
        }

        public JsonResult CreateStudent(StudentInfo studentInfo)
        {
            if (ModelState.IsValid)
            {
                db.StudentInfoes.Add(studentInfo);
                db.SaveChanges();
                return Json("Data insert");
            }
            return Json(studentInfo);
        }

        public JsonResult viewStudent()
        {
            return Json(db.StudentInfoes.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult list()
        {

            return View();
        }
    }
}