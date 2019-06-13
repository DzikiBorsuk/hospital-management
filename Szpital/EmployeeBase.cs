using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital
{
    public enum Role
    {
        Administrator,
        Lekarz,
        Pielegniarka
    }

    [Serializable]
    public abstract class EmployeeBase : IEmployee, IEquatable<EmployeeBase>
    {
        public PersonalData PersonalData { get; }
        public Role Role { get; }

        protected EmployeeBase(PersonalData personalData, Role role)
        {
            PersonalData = personalData;
            Role = role;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as EmployeeBase);
        }

        public bool Equals(EmployeeBase employee)
        {
            if (employee != null)
            {
                return this.PersonalData.Equals(employee.PersonalData) && this.Role == employee.Role;
            }

            return false;
        }
    }
}