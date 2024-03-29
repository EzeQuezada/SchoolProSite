﻿

using SchoolProSite.DAL.Entities;

namespace SchoolProSite.DAL.Interfaces
{
    public interface IDaoStudent
    {
        void SaveStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);
        Student GetStudent(int Id);
        List<Student> GetStudents();
        List<Student> GetStudents(Func<Student, bool> filter);
        bool ExistsStudent(Func<Student, bool> filter);
    }
}
