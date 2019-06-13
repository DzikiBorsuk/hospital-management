using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital
{
    [Serializable]
    public class WorkShift : IEquatable<WorkShift>
    {
        public DateTime Date { get; }
        private List<User> _user;

        public WorkShift(DateTime date)
        {
            Date = date;
            _user = new List<User>();
        }

        public List<User> Users => _user; //getter

        public void AssignEmployee(User employee)
        {
            if (CheckIfAssigned(employee))
            {
                throw new EmployeeAlreadyAssignedException(employee.EmployeeType.PersonalData.FirstName + " " +
                                                           employee.EmployeeType.PersonalData.LastName);
            }

            if (employee.EmployeeType is Doctor doctor)
            {
                if (CheckIfSpecialityAssigned(doctor.Speciality))
                {
                    throw new SpecialityAlreadyAssignedException(doctor.Speciality.ToString());
                }
            }

            _user.Add(employee);
        }

        public void RemoveEmployee(User employee)
        {
            if (!_user.Remove(employee))
            {
                throw new EmployeeIsNotAssignedException(employee.EmployeeType.PersonalData.FirstName + " " +
                                                         employee.EmployeeType.PersonalData.LastName);
            }
        }

        public bool CheckIfAssigned(User employee)
        {
            return _user.Contains(employee);
        }

        public bool CheckIfSpecialityAssigned(Speciality speciality)
        {
            foreach (var employee in _user)
            {
                if (employee.EmployeeType is Doctor doctor)
                {
                    if (doctor.Speciality == speciality)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsEmpty()
        {
            return _user.Count != 0;
        }

        public bool Equals(WorkShift other)
        {
            if (other != null)
            {
                return this.Date.Equals(Date);
            }

            return false;
        }
    }
}