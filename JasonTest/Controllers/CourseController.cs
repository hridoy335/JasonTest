using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JasonTest.Models;

namespace JasonTest.Controllers
{
    public class CourseController : Controller
    {
        Models.StudentEntities db = new StudentEntities();
     
     
        public ActionResult CourseList()
        {
            return View();
        }
        

        [HttpGet]
        public ActionResult EditCourse(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Course course = db.Courses.Find(id);
            if (course==null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CourseList");
            }
            return View(course);
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