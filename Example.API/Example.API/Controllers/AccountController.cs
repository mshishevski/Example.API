using Example.API.DataAccess.Interfaces;
using Example.API.DataAccess.Models;
using Example.API.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.API.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<List<Account>> GetAccountsByName([FromQuery] string name)
        {
            if (name == null || name.Length == 0)
                throw new Exception("Invalid Name");

            var response = await _accountService.GetAccountByName(name);
            return response;
        }

    }
}
