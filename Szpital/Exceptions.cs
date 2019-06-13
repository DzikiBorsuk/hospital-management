using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException(string name)
            : base("User: " + name + " already exists.")
        {
        }
    }

    public class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException(string name)
            : base("User: " + name + " does not exist.")
        {
        }
    }

    public class EmployeeAlreadyAssignedException : Exception
    {
        public EmployeeAlreadyAssignedException(string name)
            : base("Employee: " + name + " aleardy assigned.")
        {
        }
    }

    public class EmployeeIsNotAssignedException : Exception
    {
        public EmployeeIsNotAssignedException(string name)
            : base("Employee: " + name + " is not assigned.")
        {
        }
    }

    public class SpecialityAlreadyAssignedException : Exception
    {
        public SpecialityAlreadyAssignedException(string name)
            : base("Speciality: " + name + " already assigned.")
        {
        }
    }

    public class MonthylAssignmentExceeded : Exception
    {
        public MonthylAssignmentExceeded(string name)
            : base("Employee: " + name + " exceeded maximum monthly assignment.")
        {
        }
    }
}
