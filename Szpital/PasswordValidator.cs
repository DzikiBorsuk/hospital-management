using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital
{
    [Serializable]
    internal class PasswordValidator
    {
        private int passwordHash;

        public PasswordValidator(string password)
        {
            this.passwordHash = password.GetHashCode(); //troche prymitywne
        }

        public bool ValidatePassword(int passwordHash)
        {
            return this.passwordHash == passwordHash;
        }

        public bool ValidatePassword(string passwordString)
        {
            return this.passwordHash == passwordString.GetHashCode();
        }
    }
}
