

using SchoolProSite.DAL.Context;
using SchoolProSite.DAL.Entities;
using SchoolProSite.DAL.Exception;
using SchoolProSite.DAL.Interfaces;
using System.Xml.XPath;

namespace SchoolProSite.DAL.Dao
{
    public class DaoDeparment : IDaoDeparment
    {
        private readonly SchoolContext context;

        public DaoDeparment(SchoolContext context) 
        {
            this.context = context;
        }
        public bool ExistDeparments(Func<Department, bool> filter)
        {
            return this.context.Departments.Any(filter);
        }

       

        public Department? GetDeparment(int Id)
        {
            return this.context.Departments.Find(Id);
        }
        public List<Department> GetAllDeparments()
        {
            return this.context.Departments.ToList();
        }   

        public Department GetDeparment(int Id)
        {
            return this.context.Departments.Find(Id);
        }

        public List<Department> GetDepartments(Func<Department, bool> filter)
        {
            return this.context.Departments.Where(filter).ToList();
        }

        public void RemoveDeparment(Department department)
        {
            Department departmentToRemove = this.GetDeparment(department.DepartmentId);
            
            departmentToRemove.Deleted = department.Deleted;
            departmentToRemove.DeletedDate = department.DeletedDate;
            departmentToRemove.UserDeleted = department.UserDeleted;

            this.context.Departments.Update(departmentToRemove);
            this.context.SaveChanges();
        }

        public void SaveDeparment(Department department)
        {

            string message = string.Empty;
            if (!IsDepartmentValid(department, ref message,Operations.save))
            {
                throw new DaoDepartmentException(message);
            }

            if (this.ExistDeparments(cd => cd.Name == department.Name))
                throw new DaoDepartmentException("El departamento ya se encuentra registrado. ");
            
                

            this.context.Departments.Add(department);
            this.context.SaveChanges();
        }

        public void UpdateDeparment(Department department)
        {
            string message = string.Empty;
            if (IsDepartmentValid(department, ref message, Operations.Update))
            {
                throw new DaoDepartmentException(message);    
            }

            Department departmentToUpdate = this.GetDeparment(department.DepartmentId);

            departmentToUpdate.ModifyDate = department.ModifyDate;
            departmentToUpdate.Name = department.Name;
            department.StartDate = department.StartDate;
            departmentToUpdate.Budget = department.Budget;
            departmentToUpdate.Administrator = department.Administrator;
            departmentToUpdate.UserMod=department.UserMod;

            this.context.Departments.Update(departmentToUpdate);
            this.context.SaveChanges();

        }

        private bool IsDepartmentValid(Department department, ref string message, Operations operations) 
        { 
            bool result = false;
            if (string.IsNullOrEmpty(department.Name))
            {
                message = "El nombre del departamento es requerido.";
                return result;
            }
               

            if (department.Name.Length > 50)
            {
                message = "El nombre no puede ser mayor a 50 caracteres.";
                return result;

            }
               

            if (department.Budget == 0)
            {
                message = "El presupuesto no puede ser cero(0).";
                return result;
            }
            if (operations == Operations.save)
            {
                if (this.ExistDeparments(cd => cd.Name == department.Name))
                {
                    message = "El departamento ya se encuentra registrado. "; 
                    return  result;
                }
                
            }

            else
                result = true;
            return result;
        }
    }
}
