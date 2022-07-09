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
        public User GetUserById(int id);
        public bool CreateUser(User userNew);
        public bool DeleteUserById(int id);
        public bool ChangeUser(User userNew);
        public int? FindUserByLoginAndPassword(string login, string password);
    }
}
