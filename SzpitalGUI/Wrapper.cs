using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szpital;

namespace SzpitalGUI
{
    [Serializable]
    class Wrapper
    {
        public UsersList UsersList;
        public WorkShiftList WorkShiftList;

        public Wrapper()
        {
            UsersList = new UsersList();
            WorkShiftList = new WorkShiftList();
        }
        public Wrapper(UsersList usersList, WorkShiftList workShiftList)
        {
            UsersList = usersList;
            WorkShiftList = workShiftList;
        }
    }
}
