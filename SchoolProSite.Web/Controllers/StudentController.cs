using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProSite.DAL.Entities;
using SchoolProSite.DAL.Interfaces;
using SchoolProSite.Web.Models;

namespace SchoolProSite.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IDaoStudent daoStudent;

        public StudentController(IDaoStudent daoStudent)
        {
            this.daoStudent = daoStudent;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var students = this.daoStudent.GetStudents().Select(cd => new StudentModel()
            {
                StudentId = cd.StudentId,
                FirstName = cd.FirstName,
                LastName = cd.LastName,
                EnrollmentDate = cd.EnrollmentDate,
                CreationDate = cd.CreationDate
            });
            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var students = this.daoStudent.GetStudent(id);
            var modelStu = new StudentModel()
            {
                StudentId = students.StudentId,
                FirstName = students.FirstName,
                LastName = students.LastName,
                EnrollmentDate = students.EnrollmentDate,
                CreationDate = students.CreationDate
            };
            return View(modelStu);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModel studentModel)
        {
            try
            {
                Student student = new Student()
                {
                    StudentId = studentModel.StudentId,
                    FirstName = studentModel.FirstName,
                    LastName = studentModel.LastName,
                    EnrollmentDate = studentModel.EnrollmentDate,
                    UserMod = 1,
                    ModifyDate = DateTime.Now,

                };

                this.daoStudent.SaveStudent(student);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id,string name)
        {
            var students = this.daoStudent.GetStudent(id);

            var modelStu = new StudentModel()
            {
                StudentId = students.StudentId,
                FirstName = students.FirstName,
                LastName = students.LastName,
                EnrollmentDate = students.EnrollmentDate,
                CreationDate = students.CreationDate,
                
            };
            return View(modelStu);
            
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentModel studentModel)
        {
            try
            {
                Student student = new Student()
                {
                    StudentId = studentModel.StudentId,
                    FirstName = studentModel.FirstName,
                    LastName = studentModel.LastName,
                    EnrollmentDate = studentModel.EnrollmentDate,
                    CreationDate = studentModel.CreationDate
                };
                this.daoStudent.UpdateStudent(student);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
