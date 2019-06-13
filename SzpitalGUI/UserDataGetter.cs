using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Szpital;

namespace SzpitalGUI
{
    public class UserDataGetter
    {
        public UserDataGetter(User user)
        {
            FirstName = user.EmployeeType.PersonalData.FirstName;
            LastName = user.EmployeeType.PersonalData.LastName;
            Role = user.EmployeeType.Role.ToString();
            if (user.EmployeeType is Doctor doctor)
            {
                Speciality = doctor.Speciality.ToString();
                PWZ = doctor.PWZ;
            }
            else
            {
                Speciality = "";
            }

            Username = user.Username;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Role { get; }
        public string Speciality { get; }

        public string PWZ { get; }

        public string Username { get; }
    }
}
