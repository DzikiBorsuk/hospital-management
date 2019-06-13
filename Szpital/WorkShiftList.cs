using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital
{
    [Serializable]
    public class WorkShiftList
    {
        private List<WorkShift> _workShifts;

        public WorkShiftList()
        {
            _workShifts = new List<WorkShift>();
        }

        public void AssignEmployee(User employee, DateTime date)
        {
            if (CheckMonthlyAssignment(employee, date) > 9)
            {
                throw new MonthylAssignmentExceeded(employee.EmployeeType.PersonalData.FirstName + " " +
                                                employee.EmployeeType.PersonalData.LastName);
            }
            int index = _workShifts.FindIndex(x => x.Date.Equals(date));
            if (index == -1)
            {
                _workShifts.Add(new WorkShift(date));
                index = _workShifts.FindIndex(x => x.Date.Equals(date));
                _workShifts[index].AssignEmployee(employee);
            }
            else
            {
                if (_workShifts[index].CheckIfAssigned(employee))
                {
                    throw new EmployeeAlreadyAssignedException(employee.EmployeeType.PersonalData.FirstName + " " +
                                                               employee.EmployeeType.PersonalData.LastName);
                }
                else if (employee.EmployeeType is Doctor doctor)
                {
                    if (_workShifts[index].CheckIfSpecialityAssigned(doctor.Speciality))
                    {
                        throw new SpecialityAlreadyAssignedException(doctor.Speciality.ToString());
                    }
                }
                else
                {
                    _workShifts[index].AssignEmployee(employee);
                }
            }
        }

        public void RemoveEmployee(User employee, DateTime date)
        {
            int index = _workShifts.FindIndex(x => x.Date.Equals(date));
            if (index != -1)
            {
                _workShifts[index].RemoveEmployee(employee);
                if (_workShifts[index].IsEmpty())
                {
                    _workShifts.RemoveAt(index);
                }
            }
            else
            {
                throw new EmployeeIsNotAssignedException(employee.EmployeeType.PersonalData.FirstName + " " +
                                                         employee.EmployeeType.PersonalData.LastName);
            }
        }

        public int CheckMonthlyAssignment(User employee, DateTime date)
        {
            int counter = 0;
            foreach (var workShift in _workShifts)
            {
                if (workShift.Date.Month == date.Month)
                {
                    counter++;
                }
            }

            return counter;
        }

        public void RemoveEmployeeWholeRange(User employee)
        {
            foreach (var workShift in _workShifts)
            {
                try
                {
                    workShift.RemoveEmployee(employee);
                    if (workShift.IsEmpty())
                    {
                        _workShifts.Remove(workShift);
                    }
                }
                catch (Exception e)
                {
                    // ignored
                }
            }
        }

        public bool CheckIfAssigned(User employee, DateTime date)
        {
            int index = _workShifts.FindIndex(x => x.Date.Equals(date));
            if (index != -1)
            {
                return _workShifts[index].CheckIfAssigned(employee);
            }

            return false;
        }

        public bool CheckIfSpecialityAssigned(Speciality speciality, DateTime date)
        {
            int index = _workShifts.FindIndex(x => x.Date.Equals(date));
            if (index != -1)
            {
                return _workShifts[index].CheckIfSpecialityAssigned(speciality);
            }

            return false;
        }

        public WorkShift GetWorkShift(DateTime date)
        {
            int index = _workShifts.FindIndex(x => x.Date.Equals(date));
            if (index != -1)
            {
                return _workShifts[index];
            }

            return null;
        }
    }
}