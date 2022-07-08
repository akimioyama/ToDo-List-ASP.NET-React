﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain;
using ToDoList.EntityFramework.Repository.Interfaces;

namespace ToDoList.EntityFramework.Repository.Implementation
{
    public class CategorySelects : ICategorySelects
    {
        public HttpResponseMessage CreateCategory(HttpRequestMessage request, Category categoryNew)
        {
            using (TodoListContext db = new TodoListContext())
            {
                try
                {
                    if (categoryNew.UserId != 0)
                    {
                        db.Categories.Add(categoryNew);
                        db.SaveChanges();
                        return request.CreateResponse(HttpStatusCode.OK, "Категорию добавили");
                    }
                    else
                    {
                        return request.CreateResponse(HttpStatusCode.BadRequest, "Категорию НЕ добавили");
                    }


                }
                catch (Exception ex)
                {
                    //_logger.LogError($"Failed to get all Machine types: {ex}");
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
        }
        public Category GetCategoryById(int id)
        {
            using (TodoListContext db = new TodoListContext())
            {
                var category = db.Categories.FirstOrDefault(n => n.Id == id);
                return category;
            }
        }
        public List<Category> GetCategoriesByUserId(int userId)
        {
            using (TodoListContext db = new TodoListContext())
            {
                var categories = db.Categories.Where(c => c.UserId == userId).ToList();
                return categories;
            }
        }
        public bool ChangeCategory(Category categoryNew)
        {
            using (TodoListContext db = new TodoListContext())
            {
                try
                {
                    Category category = db.Categories.FirstOrDefault(c => c.Id == categoryNew.Id);
                    if (category != null)
                    {
                        category = categoryNew;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool DeleteCategoryById(int id)
        {
            using (TodoListContext db = new TodoListContext())
            {
                try
                {
                    Category category = db.Categories.FirstOrDefault(c => c.Id == id);
                    if (category != null)
                    {
                        db.Categories.Remove(category);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}