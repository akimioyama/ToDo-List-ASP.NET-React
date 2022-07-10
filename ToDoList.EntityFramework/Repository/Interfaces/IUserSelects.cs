using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain;

namespace ToDoList.EntityFramework.Repository.Interfaces
{
    public interface IUserSelects
    {
        public bool CreateUser(User userNew);
        public User GetUserById(int id);
        public bool ChangeUser(User userNew);
        public bool DeleteUserById(int id);
        public int? FindUserIdByLoginAndPassword(string login, string password);
    }
}
