using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProSite.DAL.Entities;
using SchoolProSite.DAL.Interfaces;
using SchoolProSite.Web.Models;

namespace SchoolProSite.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDaoDepartment daoDepartment;

        public DepartmentController(IDaoDepartment daoDepartment) 
        {
            this.daoDepartment = daoDepartment;
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            var departments = this.daoDepartment.GetDepartments()
                .Select(cd => new DepartmentGetModel()
                {
                    Administrator = cd.Administrator,
                    DepartmentId = cd.DepartmentId,
                    Budget = cd.Budget,
                    Name = cd.Name,
                    StarDate = cd.StartDate
                });

            return View(departments);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var department = this.daoDepartment.GetDepartment(id);

            var modelDepto = new DepartmentGetModel()
            {
                DepartmentId = department.DepartmentId,
                Administrator = department.Administrator,
                Budget = department.Budget,
                Name = department.Name,
                StarDate = department.StartDate
            };

            return View(modelDepto);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentGetModel departmentModel)
        {
            try
            {
                Department department = new Department()
                {
                    Administrator = departmentModel.Administrator,
                    Name = departmentModel.Name,
                    Budget = departmentModel.Budget,
                    UserMod = 1,
                    CreationUser = 1,
                    CreationDate = DateTime.Now,
                    StartDate = departmentModel.StarDate,


                };

                this.daoDepartment.SaveDepartment(department);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var department = this.daoDepartment.GetDepartment(id);

            var modelDepto = new DepartmentGetModel()
            {
                DepartmentId = department.DepartmentId,
                Administrator = department.Administrator,
                Budget = department.Budget,
                Name = department.Name,
                StarDate = department.StartDate
            };
            return View(modelDepto);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentGetModel departmentModel)
        {

            try
            {
                Department department= new Department()
                {
                    Administrator= departmentModel.Administrator,
                    Name=departmentModel.Name,
                    Budget=departmentModel.Budget,
                    CreationUser=1,
                    StartDate=departmentModel.StarDate,
                    DepartmentId=departmentModel.DepartmentId,
                };

                this.daoDepartment.UpdateDepartment(department);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
