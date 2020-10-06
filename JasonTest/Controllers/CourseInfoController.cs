using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JasonTest.Models;

namespace JasonTest.Controllers
{
    public class CourseInfoController : Controller
    {
        Models.StudentEntities db = new StudentEntities();

        // GET: CourseInfo

        public ActionResult index()
        {

            return View();
        }

        public ActionResult SideMenu()
        {
            return PartialView("SideMenu");
        }

        public ActionResult Partial1()
        {
            return PartialView("Partial1");
        }

        public JsonResult GetEmployeeRecord()
        {
            
            //  MVCTutorialEntities db = new MVCTutorialEntities();


            List<Course>  ds = db.Courses.ToList();

            return Json(ds, JsonRequestBehavior.AllowGet);

        }
        //[HttpPost]
        //public ActionResult Index(EmployeeViewModel model)
        //{
        //    try
        //    {
        //        MVCTutorialEntities db = new MVCTutorialEntities();
        //        List<Department> list = db.Departments.ToList();
        //        ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");

        //        if (model.EmployeeId > 0)
        //        {
        //            //update
        //            Employee emp = db.Employees.SingleOrDefault(x => x.EmployeeId == model.EmployeeId && x.IsDeleted == false);

        //            emp.DepartmentId = model.DepartmentId;
        //            emp.Name = model.Name;
        //            emp.Address = model.Address;
        //            db.SaveChanges();


        //        }
        //        else
        //        {
        //            //Insert
        //            Employee emp = new Employee();
        //            emp.Address = model.Address;
        //            emp.Name = model.Name;
        //            emp.DepartmentId = model.DepartmentId;
        //            emp.IsDeleted = false;
        //            db.Employees.Add(emp);
        //            db.SaveChanges();

        //        }
        //        return View(model);

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}

        public ActionResult AddEditEmployee(int CourseId)
        {

            //List<Department> list = db.Departments.ToList();
            //ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");

            // EmployeeViewModel model = new EmployeeViewModel();
            Course course = new Course();

            if (CourseId > 0)
            {

                Course emp  = db.Courses.SingleOrDefault(x => x.CourseId == CourseId);
                course.CourseId = emp.CourseId;
                course.CourseName = emp.CourseName;
                course.CourseCredit = emp.CourseCredit;
                

            }
            return PartialView("Partial2", course);
        }

        // Add new course
        public ActionResult AddCourseInfo()
        {
            return PartialView("Partial1");
        }

        [HttpPost]
        public JsonResult CoueseCreate(Course course)
        {
          
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return Json("Insert successfull");
            }
            return Json("Not Insert");
        }

        //Edit Course
        [HttpGet]
        public ActionResult EditCourse(int? CourseId)
        {
            if (CourseId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(CourseId);
            if (course==null)
            {
                return HttpNotFound();
            }
           
            return PartialView("SideMenu",course);
        }

        [HttpPost]
        public JsonResult EditCourse([Bind(Include = "CourseId,CourseName,Role,CourseCredit")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return Json("Insert successfull");
            }
            return Json("Not Insert");
        }

        // Delete Course 
        [HttpGet]
        public ActionResult DeleteCourse(int? CourseId)
        {
            if (CourseId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(CourseId);
            if (course == null)
            {
                return HttpNotFound();
            }

             return PartialView("DeletePartial", course);
           // return View();
        }
        public ActionResult DeletePartial()
        {
            return PartialView("DeletePartial");
        }

        [HttpPost]
        public ActionResult DeleteCourse(int? CourseId, Course course)
        {
            if (CourseId != null)
            {
                Course course1 = db.Courses.Find(CourseId);
                db.Courses.Remove(course1);
                db.SaveChanges();
                return Json("Delete successfull");
            }
            return Json("System can.t delete this Data");
        }
    }
}