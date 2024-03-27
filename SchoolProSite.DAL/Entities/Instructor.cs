
using SchoolProSite.DAL.Core;

namespace SchoolProSite.DAL.Entities
{
    public partial class Instructor : PersonBase
    {
        public int InstructorId { get; set; }
        public DateTime? HireDate { get; set; }
        
    }
}