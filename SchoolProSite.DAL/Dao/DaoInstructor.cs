using SchoolProSite.DAL.Context;
using SchoolProSite.DAL.Entities;
using SchoolProSite.DAL.Interfaces;


namespace SchoolProSite.DAL.Dao
{
    internal class DaoInstructor : IDaoInstructor
    {
        private readonly SchoolContext context;

        public DaoInstructor(SchoolContext context)
        {
            this.context = context;
        }
        public bool ExistsInstructor(Func<Instructor, bool> filter)
        {
            ;
        }

        public Instructor GetInstructor(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Instructor> GetInstructors()
        {
            throw new NotImplementedException();
        }

        public List<Instructor> GetInstructors(Func<Instructor, bool> filter)
        {
            throw new NotImplementedException();
        }

        public void RemoveInstructor(Instructor instructor)
        {
            throw new NotImplementedException();
        }

        public void SaveInstructor(Instructor instructor)
        {
            throw new NotImplementedException();
        }

        public void UpdateInstructor(Instructor instructor)
        {
            throw new NotImplementedException();
        }
    }
}
