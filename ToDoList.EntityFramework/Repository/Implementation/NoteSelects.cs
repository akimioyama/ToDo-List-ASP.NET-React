using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Description;
using ToDoList.Domain;
using ToDoList.EntityFramework.Repository.Interfaces;

namespace ToDoList.EntityFramework.Repository.Implementation
{
    public class NoteSelects : INoteSelects
    {
        //[ResponseType(typeof(Note))]
        public bool CreateNote(Note noteNew)
        {
            using (TodoListContext db = new TodoListContext())
            {
                try
                {
                    if (noteNew.CategoryId != 0)
                    {
                        db.Notes.Add(noteNew);
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
                    //_logger.LogError($"Failed to get all Machine types: {ex}");
                    return false;
                }
            }
        }
        public Note GetNoteById(int id)
        {
            using (TodoListContext db = new TodoListContext())
            {
                var note = db.Notes.FirstOrDefault(n => n.Id == id);
                return note;
            }
        }
        public List<Note> GetNoteByCategoryId(int categoryId)
        {
            using (TodoListContext db = new TodoListContext())
            {
                var notes = db.Notes.Where(n => n.CategoryId == categoryId).ToList();
                return notes;
            }
        }
        public List<Note> GetNoteByUserId(int userId)
        {
            using (TodoListContext db = new TodoListContext())
            {
                //к Notes добоволяем Category, так как в Notes только Id категории, а мы по ID user смотрим
                //а он есть как раз в Category
                var notes = db.Notes.Include(n => n.Category).Where(c => c.Category.UserId == userId).ToList();
                return notes;
            }
        }
        public bool ChangeNote(Note noteNew)
        {
            using (TodoListContext db = new TodoListContext())
            {
                try
                {
                    Note note = db.Notes.FirstOrDefault(n => n.Id == noteNew.Id);
                    if (note != null)
                    {
                        note = noteNew;
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
        public bool DeleteNoteById(int id)
        {
            using (TodoListContext db = new TodoListContext())
            {
                try
                {
                    Note note = db.Notes.FirstOrDefault(n => n.Id == id);
                    if (note != null)
                    {
                        db.Notes.Remove(note);
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
