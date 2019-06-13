using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital
{
    [Serializable]
    public class Administrator : EmployeeBase, IAdministrator
    {
        public Administrator(PersonalData personalData) : base(personalData, Role.Administrator)
        {
        }
    }
}