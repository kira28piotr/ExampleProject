using System.Linq;
using System.Net;
using System.Web.Mvc;
using ExampleProject.DataProvider;
using ExampleProject.Models;

namespace ExampleProject.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentDataProvider _studentDataProvider;

        public StudentsController(IStudentDataProvider studentDataProvider)
        {
            _studentDataProvider = studentDataProvider;
        }

        public ActionResult Index()
        {
            return View(_studentDataProvider.GetAllStudents().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var student = _studentDataProvider.GetStudentById(id);
            if (student == null)
                return HttpNotFound();
            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentDataProvider.SaveStudent(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var student = _studentDataProvider.GetStudentById(id);
            if (student == null)
                return HttpNotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentDataProvider.SaveStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var student = _studentDataProvider.GetStudentById(id);
            if (student == null)
                return HttpNotFound();
            return View(student);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _studentDataProvider.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}