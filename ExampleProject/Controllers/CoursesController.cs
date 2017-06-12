using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExampleProject.Data;
using ExampleProject.DataProvider;
using ExampleProject.Models;

namespace ExampleProject.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseDataProvider _courseDataProvider;

        public CoursesController(ICourseDataProvider courseDataProvider)
        {
            _courseDataProvider = courseDataProvider;
        }

        public ActionResult Index()
        {
            return View(_courseDataProvider.GetAllCourses().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var course = _courseDataProvider.GetCourseById(id);
            if (course == null)
                return HttpNotFound();
            return View(course);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseDataProvider.SaveCourse(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var course = _courseDataProvider.GetCourseById(id);
            if (course == null)
                return HttpNotFound();
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseDataProvider.SaveCourse(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var course = _courseDataProvider.GetCourseById(id);
            if (course == null)
                return HttpNotFound();
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _courseDataProvider.DeleteCourse(id);
            return RedirectToAction("Index");
        }

    }
}
