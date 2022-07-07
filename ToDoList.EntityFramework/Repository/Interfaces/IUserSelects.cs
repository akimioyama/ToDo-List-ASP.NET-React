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
    }
}
