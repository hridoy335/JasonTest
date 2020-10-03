using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JasonTest.Models;
namespace JasonTest.Controllers
{
    public class TeacherController : Controller
    {
        StudentEntities db = new StudentEntities();

        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TeacherCreate()
        {
            return View();
        }

        public ActionResult TeacherSelect()
        {

            // return Json(new { Abc = db.Teachers.ToList() }, JsonRequestBehavior.AllowGet);
           
            return View();
            
        }
        public JsonResult CreateTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return Json("Insert successfull");
            }
            return Json("Not Insert");
        }

        public JsonResult ViewTeacher()
        {
            
            return Json(/*new { data =*/ db.Teachers.ToList() /*}*/, JsonRequestBehavior.AllowGet);
        }

        



    }
}