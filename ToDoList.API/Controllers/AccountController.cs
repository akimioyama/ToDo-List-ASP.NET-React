using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Application.DTO;
using ToDoList.Application.Serviсes.Interfaces;
using ToDoList.Common.Extension;
using Microsoft.AspNetCore.Authorization;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAccountInfo()
        {
            var jwt = Request.Headers.GetJwt();
            return Json(_accountService.GetAccountInfoByJwt(jwt));
        }
        [HttpPost]
        public async Task<IActionResult> Login(string login, string password)
        {
            return Json(_accountService.Login(login, password));
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> ChangeAccount(AccountDTO accountDTO)
        {
            var jwt = Request.Headers.GetJwt();
            return Json(_accountService.ChangeAccountInfoByJwt(accountDTO, jwt));
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(AccountDTO accountDTO)
        {
            var jwt = Request.Headers.GetJwt();
            return Json(_accountService.DeleteAccountInfoByJwt(jwt));
        }
    }
}
