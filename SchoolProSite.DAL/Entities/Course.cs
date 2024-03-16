
using SchoolProSite.DAL.Core;

namespace SchoolProSite.DAL.Entities;

public partial class Course : BaseEntity
{
    public int CourseId { get; set; }

    public string Title { get; set; }

    public int Credits { get; set; }

    public int DepartmentId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int CreationUser { get; set; }

    public int? UserMod { get; set; }

    public int? UserDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool Deleted { get; set; }

    public virtual Department Department { get; set; }

    public virtual OnlineCourse OnlineCourse { get; set; }

    public virtual OnsiteCourse OnsiteCourse { get; set; }

    public virtual ICollection<StudentGrade> StudentGrades { get; set; } = new List<StudentGrade>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}