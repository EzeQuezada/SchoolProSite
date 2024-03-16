using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProSite.DAL.Exception
{
    public class DaoDepartmentException : IOException
    {
        public DaoDepartmentException(string message) : base(message)
        {
            //x Logica para guardar el error.
        }
    }
}
