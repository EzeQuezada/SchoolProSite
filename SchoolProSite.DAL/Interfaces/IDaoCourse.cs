
using SchoolProSite.DAL.Entities;

namespace SchoolProSite.DAL.Interfaces
{
    public interface IDaoCourse
    {
        void SaveCourses(Course course);
        void UpdatingCourse(Course course);
        void Removies(Course course);
        Course GetCourseById(int id);
        List<Course> GetCourses();
        List<Course> GetCourses(Func<Course, bool>Filter);

        bool ExitsCourses(Func<Course, bool>Filter);
        


    }
}
