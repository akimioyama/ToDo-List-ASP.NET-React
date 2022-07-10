using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain;

namespace ToDoList.EntityFramework.Repository.Interfaces
{
    public interface INoteSelects
    {
        public bool CreateNote(Note noteNew);
        public Note GetNoteById(int id);
        public List<Note> GetNoteByCategoryId(int categoryId);
        public List<Note> GetNoteByUserId(int userId);
        public bool ChangeNote(Note noteNew);
        public bool ChangeStatusNote(int id, bool status);
        public bool DeleteNoteById(int id);
    }
}
