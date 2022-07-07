using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain;
using ToDoList.EntityFramework.Repository.Interfaces;

namespace ToDoList.EntityFramework.Repository.Implementation
{
    public class UserSelects : IUserSelects
    {
        public User GetUserById(int id)
        {
            using (TodoListContext db = new TodoListContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                return user;
            }
        }
    }
}
