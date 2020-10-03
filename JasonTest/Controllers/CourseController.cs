using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JasonTest.Models;

namespace JasonTest.Controllers
{
    public class CourseController : Controller
    {
        Models.StudentEntities db = new StudentEntities();
        // GET: Course
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult CourseList()
        {
            return View();
        }
        public ActionResult CourseListAll()
        {
            return View();
        }
        public JsonResult GetEmployeeRecord()
        {

            //MVCTutorialEntities db = new MVCTutorialEntities();

            //List<Course> List = db.Courses.Select(x => new Course
            //{
            //    CourseId=x.CourseId,
            //    CourseName = x.CourseName,
            //    CourseCredit = x.CourseCredit          
            //}).ToList();

            return Json(db.Courses.ToList(), JsonRequestBehavior.AllowGet);

        }
    }
}