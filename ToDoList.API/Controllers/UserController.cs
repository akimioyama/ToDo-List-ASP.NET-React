using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class UserController : ControllerBase
    {
        private readonly IUserServiсe _userServise;

        public UserController(IUserServiсe userServise)
        {
            _userServise = userServise;
        }

        [Authorize]
        [HttpGet]
        public async Task<UserDTO> GetUser()
        {
            var jwt = Request.Headers.GetJwt();
            return new UserDTO();
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> GetUser(int id)
        {
            var jwt = Request.Headers.GetJwt();
            return _userServise.GetUserInfo(id);
        }
    }
}
