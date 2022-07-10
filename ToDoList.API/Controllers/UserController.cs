using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Application.DTO;
using ToDoList.Application.Serviсes.Interfaces;
using ToDoList.Common.Extension;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserServiсe _userServise;

        public UserController(IUserServiсe userServise)
        {
            _userServise = userServise;
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            return Json(_userServise.AddUser(userDTO));
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserInfo(int id)
        {

            return Json(_userServise.GetUserById(id));
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> ChangeUser(UserDTO userDTO)
        {
            return Json(_userServise.ChangeUser(userDTO));
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return Json(_userServise.DeleteUserById(id));
        }
    }
}

