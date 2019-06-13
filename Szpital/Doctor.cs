using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital
{
    public enum Speciality
    {
        Kardiolog,
        Urolog,
        Neurolog,
        Laryngolog
    }

    [Serializable]
    public class Doctor : EmployeeBase, IDoctor
    {
        public string PWZ { get; }
        public Speciality Speciality { get; }

        public Doctor(PersonalData personalData, string pwz, Speciality speciality) : base(personalData, Role.Lekarz)
        {
            PWZ = pwz;
            Speciality = speciality;
        }
    }
}
