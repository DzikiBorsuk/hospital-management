using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital
{
    [Serializable]
    public class PersonalData
    {
        public PersonalData(string firstName, string lastName, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; }

        public bool Equals(PersonalData personalData)
        {
            return this.FirstName.Equals(personalData.FirstName) && this.LastName.Equals(personalData.LastName) &&
                   this.Address.Equals(personalData.Address);
        }
    }
}