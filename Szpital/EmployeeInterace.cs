using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital
{
    public interface IEmployee
    {
        PersonalData PersonalData { get; }
        Role Role { get; }
    }

    internal interface IAdministrator : IEmployee
    {
        //puste
    }

    internal interface IDoctor : IEmployee
    {
        String PWZ { get; }
        Speciality Speciality { get; }

    }

    internal interface INurse : IEmployee
    {
        //puste
    }
}
