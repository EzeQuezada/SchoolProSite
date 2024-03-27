namespace SchoolProSite.Web.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser {  get; set; }
        public int UserMod { get; set; }
    }
}
