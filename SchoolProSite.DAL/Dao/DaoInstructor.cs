using SchoolProSite.DAL.Context;
using SchoolProSite.DAL.Entities;
using SchoolProSite.DAL.Interfaces;
using SchoolProSite.DAL.Exceptions;



namespace SchoolProSite.DAL.Dao
{
    public class DaoInstructor : IDaoInstructor
    {
        private readonly SchoolContext context;

        public DaoInstructor(SchoolContext context)
        {
            this.context = context;
        }
        public bool ExistsInstructor(Func<Instructor, bool> filter)
        {
            return this.context.Instructors.Any(filter);
        }

        public Instructor GetInstructor(int Id)
        {
            return this.context.Instructors.Find(Id);
        }

        public List<Instructor> GetInstructors()
        {
            return this.context.Instructors
                .OrderByDescending(Instro => Instro.CreationDate)
                .ToList();
        }

        public List<Instructor> GetInstructors(Func<Instructor, bool> filter)
        {
            return this.context.Instructors.Where(filter).ToList();
        }

        public void RemoveInstructor(Instructor instructor)
        {
            Instructor instructorToRemove = this.GetInstructor(instructor.InstructorId);

            instructorToRemove.Deleted = instructor.Deleted;
            instructorToRemove.DeletedDate = instructor.DeletedDate;
            instructorToRemove.UserDeleted = instructor.UserDeleted;

            this.context.Instructors.Update(instructorToRemove);

            this.context.SaveChanges();
        }

        public void SaveInstructor(Instructor instructor)
        {
            string message = string.Empty;

            if (!IsInstructorValid(instructor, ref message, Operations.Update))
                throw new DaoInstructorException(message);

            this.context.Instructors.Add(instructor);

            this.context.SaveChanges();
        }

        public void UpdateInstructor(Instructor instructor)
        {
            string message = string.Empty;

            if (!IsInstructorValid(instructor, ref message, Operations.Update))
                throw new DaoInstructorException(message);

            Instructor instructoToUpdate = this.GetInstructor(instructor.InstructorId);

            if (instructoToUpdate is null)
                throw new DaoInstructorException("El instructor no se encuentra registrado. ");

            instructoToUpdate.FirstName = instructor.FirstName;
            instructoToUpdate.LastName = instructor.LastName;
            instructoToUpdate.CreationDate = instructor.CreationDate;
            instructoToUpdate.HireDate = instructor.HireDate;
            instructoToUpdate.CreationUser = instructor.CreationUser;
            instructoToUpdate.ModifyDate = instructor.ModifyDate;   


        }

        private bool IsInstructorValid (Instructor instructor,ref string message,Operations operations) 
        {
            bool result = false;
            if (string.IsNullOrEmpty(instructor.LastName)||string.IsNullOrEmpty(instructor.FirstName))
            {
                message = "El nombre del instructor es requerido";
                return result;
            }
            if (instructor.FirstName.Length > 50)
            {
                message = "El nombre del instructo no puede tener mas de 50 caracateres. ";
                return result;
            }
            if (operations ==Operations.save) 
            {
                if (this.ExistsInstructor(cd => cd.FirstName == instructor.FirstName))
                {
                    message = "El instructor ya esta registrado. ";
                    return result;
                }
                else
                {
                    result = true;
                }

            }
            else 
                result = true;

            return result;
        }
        

    }
}
