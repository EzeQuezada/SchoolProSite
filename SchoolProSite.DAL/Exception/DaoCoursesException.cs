

namespace SchoolProSite.DAL.Exception
{
    public class DaoCoursesException : IOException
    {
        
            public DaoCoursesException(string message) : base(message)
            {
                // Logica para guardar el error en la base datos y enviar un correo.
            }
        
    }
}
