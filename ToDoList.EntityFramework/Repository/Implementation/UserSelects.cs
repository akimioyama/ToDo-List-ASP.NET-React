﻿using System;
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
        public bool CreateUser(User userNew)
        {
            using (TodoListContext db = new TodoListContext())
            {
                try
                {
                    var user = db.Users.FirstOrDefault(u => u.Login == userNew.Login);
                    if (user == null)
                    {
                        user = db.Users.FirstOrDefault(u => u.Email == userNew.Email);
                        if (null == user)
                        {
                            db.Users.Add(userNew);
                            db.SaveChanges();
                            return true;
                        }
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }
        //изменение пользователя. При удачном изменении возвращает true
        public bool ChangeUser(User userNew)
        {
            using (TodoListContext db = new TodoListContext())
            {
                try
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userNew.Id);
                    if (user != null)
                    {
                        user = userNew;
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }
        public int? FindUserByLoginAndPassword(string login, string password)
        {
            using (TodoListContext db = new TodoListContext())
            {
                try
                {
                    var user = db.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
                    if (user != null)
                    {
                        return user.Id;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
        public bool DeleteUserById(int id)
        {
            using (TodoListContext db = new TodoListContext())
            {
                try
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == id);
                    if (user != null)
                    {
                        db.Users.Remove(user);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
