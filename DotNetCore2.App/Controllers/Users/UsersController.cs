﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DotNetCore2.Controllers.Users
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        public UsersController()
        {

        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}