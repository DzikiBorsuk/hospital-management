using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital
{
    [Serializable]
    public class Nurse : EmployeeBase, INurse
    {
        public Nurse(PersonalData personalData) : base(personalData, Role.Pielegniarka) { }
    }
}
