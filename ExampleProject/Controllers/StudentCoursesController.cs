using System.Linq;
using System.Net;
using System.Web.Mvc;
using ExampleProject.DataProvider;
using ExampleProject.Models;

namespace ExampleProject.Controllers
{
    public class StudentCoursesController : Controller
    {
        private readonly ICourseDataProvider _courseDataProvider;
        private readonly IStudentCourseDataProvider _studentCourseDataProvider;
        private readonly IStudentDataProvider _studentDataProvider;

        public StudentCoursesController(IStudentCourseDataProvider studentCourseDataProvider,
            IStudentDataProvider studentDataProvider,
            ICourseDataProvider courseDataProvider)
        {
            _studentCourseDataProvider = studentCourseDataProvider;
            _studentDataProvider = studentDataProvider;
            _courseDataProvider = courseDataProvider;
        }

        public ActionResult Index()
        {
           return View(_studentCourseDataProvider.GetAllStudentCourses().ToList());
        }

        public ActionResult Details(int? id)
        {
            System.Diagnostics.Debug.WriteLine("LOOOOOOL");
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            else
                System.Diagnostics.Debug.WriteLine("kur zapiał działa");
            var studentCourse = _studentCourseDataProvider.GetRelationshipById(id);
            if (studentCourse == null)
                return HttpNotFound();
            return View(studentCourse);
        }

        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(_courseDataProvider.GetAllCourses(), "Id", "Name");
            ViewBag.StudentId = new SelectList(_studentDataProvider.GetAllStudents(), "Id", "FirstName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                _studentCourseDataProvider.SaveStudentCourse(studentCourse);
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(_courseDataProvider.GetAllCourses(), "Id", "Name", studentCourse.CourseId);
            ViewBag.StudentId = new SelectList(_studentDataProvider.GetAllStudents(), "Id", "FirstName",
                studentCourse.StudentId);
            return View(studentCourse);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var studentCourse = _studentCourseDataProvider.GetRelationshipById(id);
            if (studentCourse == null)
                return HttpNotFound();
            ViewBag.CourseId = new SelectList(_courseDataProvider.GetAllCourses(), "Id", "Name", studentCourse.CourseId);
            ViewBag.StudentId = new SelectList(_studentDataProvider.GetAllStudents(), "Id", "FirstName",
                studentCourse.StudentId);
            return View(studentCourse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                _studentCourseDataProvider.SaveStudentCourse(studentCourse);
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(_courseDataProvider.GetAllCourses(), "Id", "Name", studentCourse.CourseId);
            ViewBag.StudentId = new SelectList(_studentDataProvider.GetAllStudents(), "Id", "FirstName",
                studentCourse.StudentId);
            return View(studentCourse);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var studentCourse = _studentCourseDataProvider.GetRelationshipById(id);

    
            if (studentCourse == null)
                return HttpNotFound();
            return View(studentCourse);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _studentCourseDataProvider.DeleteStudentCourse(id);
            return RedirectToAction("Index");
        }
    }
}