using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital
{

    [Serializable]
    public class UsersList
    {
        private List<User> _users;

        public UsersList()
        {
            _users = new List<User>();
        }

        public List<User> Users => _users; //getter

        public bool CheckIfExist(string username)
        {
            return _users.Contains(new User(username, "", null));
        }
        public void AddUser(string username, string password, EmployeeBase employeeType)
        {
            if (CheckIfExist(username))
            {
                throw new UserAlreadyExistException(username);
            }
            else
            {
                _users.Add(new User(username,password,employeeType));
            }
        }

        public void AddUser(User user)
        {
            if (CheckIfExist(user.Username))
            {
                throw new UserAlreadyExistException(user.Username);
            }
            else
            {
                _users.Add(user);
            }
        }

        public void RemoveUser(string username)
        {
            if (!_users.Remove(new User(username, "", null)))
            {
                throw new UserDoesNotExistException(username);
            }
        }

        public User GetUser(string username)
        {
            int index = _users.IndexOf(new User(username, "", null));
            if (index == -1)
            {
                throw new UserDoesNotExistException(username);
            }
            else
            {
                return _users[index];
            }
        }
    }
}
