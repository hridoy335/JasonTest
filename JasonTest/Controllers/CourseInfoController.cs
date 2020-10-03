using System;
using System.Collections.Generic;
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

        //public ActionResult Index()
        //{
        //    MVCTutorialEntities db = new MVCTutorialEntities();

        //    List<Department> list = db.Departments.ToList();
        //    ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");

        //    List<EmployeeViewModel> listEmp = db.Employees.Where(x => x.IsDeleted == false).Select(x => new EmployeeViewModel { Name = x.Name, DepartmentName = x.Department.DepartmentName, Address = x.Address, EmployeeId = x.EmployeeId }).ToList();

        //    ViewBag.EmployeeList = listEmp;

        //    return View();
        //}

        public ActionResult SideMenu()
        {
            return PartialView("SideMenu");
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


    }
}