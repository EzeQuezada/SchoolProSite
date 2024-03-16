

using SchoolProSite.DAL.Entities;

namespace SchoolProSite.DAL.Interfaces
{
    public interface IDaoDeparment
    {
        void SaveDeparment(Department department);
        void UpdateDeparment(Department department);

        void RemoveDeparment(Department department);
        Department GetDeparment(int Id);

        List<Department> GetAllDeparments();
        bool ExistDeparments(Func<Department,bool>filter);
        List<Department>GetDepartments(Func<Department,bool>filter);



           
    }
}
