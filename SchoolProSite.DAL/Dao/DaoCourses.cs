

using SchoolProSite.DAL.Context;
using SchoolProSite.DAL.Entities;
using SchoolProSite.DAL.Interfaces;

namespace SchoolProSite.DAL.Dao
{
    public class DaoCourses : IDaoCourse
    {
        private readonly SchoolContext context;

        public DaoCourses(SchoolContext context) 
        {
            this.context = context;
        }
        public bool ExitsCourses(Func<Course, bool> Filter)
        {
            return this.context.Courses.Any(Filter);
        }

        public Course GetCourseById(int id)
        {
            return this.context.Courses.Find(id);
        }

        public List<Course> GetCourses()
        {
           return this.context.Courses.ToList();
        }

        public List<Course> GetCourses(Func<Course, bool> Filter)
        {
            return this.context.Courses.Where(Filter).ToList();
        }

        public void Removies(Course course)
        {
            
        }

        public void SaveCourses(Course course)
        {
            
        }

        public void UpdatingCourse(Course course)
        {
            
        }
    }
}
