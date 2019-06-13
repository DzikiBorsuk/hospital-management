using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital
{
    [Serializable]
    public class User : IEquatable<User>
    {
        public User(string username, string password, EmployeeBase employeeType)
        {
            Username = username;
            PasswordValidator = new PasswordValidator(password);
            EmployeeType = employeeType;
        }


        internal PasswordValidator PasswordValidator;

        public string Username { get; }
        public EmployeeBase EmployeeType { get; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as User);
        }

        public bool Equals(User user)
        {
            if (user != null)
            {

                return this.Username.Equals(user.Username);
            }

            return false;
        }
    }
}
