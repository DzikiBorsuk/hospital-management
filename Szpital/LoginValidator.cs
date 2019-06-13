using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital
{
    public class LoginValidator
    {
        public static bool ValidateLoginInput(string username, string password, UsersList users)
        {
            if (users.CheckIfExist(username))
            {
                var user = users.GetUser(username);
                return user.PasswordValidator.ValidatePassword(password);
            }
            else
            {
                return false;
            }
        }
    }
}
