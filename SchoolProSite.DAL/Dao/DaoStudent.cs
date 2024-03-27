using SchoolProSite.DAL.Context;
using SchoolProSite.DAL.Entities;
using SchoolProSite.DAL.Exceptions;
using SchoolProSite.DAL.Interfaces;


namespace SchoolProSite.DAL.Dao
{
    public class DaoStudent : IDaoStudent
    {
        private readonly SchoolContext context;

        public DaoStudent (SchoolContext context)
        {
            this.context = context;
        }
        public bool ExistsStudent(Func<Student, bool> filter)
        {
            return this.context.Students.Any(filter);
        }

        public Student GetStudent(int Id)
        {
            return this.context.Students.Find(Id);
        }

        public List<Student> GetStudents()
        {
            return this.context.Students.OrderByDescending(Stu => Stu.CreationDate).ToList();
        }

        public List<Student> GetStudents(Func<Student, bool> filter)
        {
            return this.context.Students.Where(filter).ToList();
        }

        public void RemoveStudent(Student student)
        {
            Student studentToRemove= this.GetStudent(student.StudentId);

            studentToRemove.Deleted = student.Deleted;
            studentToRemove.DeletedDate = student.DeletedDate;
            studentToRemove.UserDeleted = student.UserDeleted;

            this.context.Students.Update(studentToRemove);

            this.context.SaveChanges();
        }

        public void SaveStudent(Student student)
        {
            string message = string.Empty;

            if (!IsStudentValid(student, ref message, Operations.Update))
                throw new DaoStudentException(message);

            this.context.Students.Add(student);

            this.context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            string message = string.Empty;

            if (!IsStudentValid(student, ref message, Operations.Update))
                throw new DaoStudentException(message);

            Student studentToUpdate = this.GetStudent(student.StudentId);

            if (studentToUpdate is null)
                throw new DaoStudentException("El estudiante no se encuentra registrado.");

            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.CreationDate = student.CreationDate;
            studentToUpdate.CreationUser = student.CreationUser;
            studentToUpdate.ModifyDate = student.ModifyDate;
            studentToUpdate.EnrollmentDate = student.EnrollmentDate;

        }

        private bool IsStudentValid(Student student, ref string message, Operations operations)
        {
            bool result = false;
            if (string.IsNullOrEmpty(student.LastName) || string.IsNullOrEmpty(student.FirstName))
            {
                message = "El nombre del estudiante es requerido";
                return result;
            }
            if (student.FirstName.Length > 50)
            {
                message = "El nombre del estudiante no puede tener mas de 50 caracateres. ";
                return result;
            }
            if (operations == Operations.save)
            {
                if (this.ExistsStudent(cd => cd.FirstName == student.FirstName))
                {
                    message = "El estudiante ya esta registrado. ";
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
