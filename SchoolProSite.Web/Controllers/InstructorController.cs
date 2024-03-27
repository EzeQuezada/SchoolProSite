using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using SchoolProSite.DAL.Entities;
using SchoolProSite.DAL.Interfaces;
using SchoolProSite.Web.Models;

namespace SchoolProSite.Web.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IDaoInstructor daoInstructor;

        public InstructorController(IDaoInstructor daoInstructor)
        {
            this.daoInstructor = daoInstructor;
        }
        // GET: InstructorController
        public ActionResult Index()
        {
            var instructors = this.daoInstructor.GetInstructors()
                              .Select(cd => new InstructorModel() 
            {
                InstructorId=cd.InstructorId,
                FirstName = cd.FirstName,
                LastName = cd.LastName,
                HireDate = cd.HireDate,
                CreationDate = cd.CreationDate
            });
            
            return View(instructors);
        }

        // GET: InstructorController/Details/5
        public ActionResult Details(int id)
        {
            var instructor = this.daoInstructor.GetInstructor(id);
            var modelIntro = new InstructorModel()
            {
                InstructorId = instructor.InstructorId,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                HireDate = instructor.HireDate,
                
            };
            return View(modelIntro);
        }

        // GET: InstructorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstructorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstructorModel instructorModel)
        {
            try
            {
                Instructor instructor = new Instructor()
                {
                                   
          
                    FirstName = instructorModel.FirstName,
                    LastName = instructorModel.LastName,
                    HireDate = instructorModel.HireDate,
                    CreationDate = DateTime.Now,
                    CreationUser = 1
                
                };

                this.daoInstructor.SaveInstructor(instructor);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorController/Edit/5
        public ActionResult Edit(int id,string name)
        {
            var instructor = this.daoInstructor.GetInstructor(id);

            var modelIntro = new InstructorModel()
            {
                InstructorId = instructor.InstructorId,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                HireDate = instructor.HireDate,
               
            };
            return View(modelIntro);
            
        }

        // POST: InstructorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstructorModel instructorModel)
        {
            try
            {
                Instructor instructor = new Instructor()
                {
                    InstructorId = instructorModel.InstructorId,
                    FirstName = instructorModel.FirstName,
                    LastName = instructorModel.LastName,
                    HireDate = instructorModel.HireDate,

                };
                this.daoInstructor.UpdateInstructor(instructor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InstructorController/Delete/5
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
