using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using etracker_api.Models;
using Microsoft.AspNetCore.Authorization;

namespace etracker_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class LoginController : ControllerBase
    {
        private readonly etrackerContext _context;

        public LoginController(etrackerContext context)
        {
            _context = context;
        }


        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetData(Login loginInfo)
        {
            
            var LoginData = await _context.LoginInfo.FromSqlRaw("DoLogin '" + loginInfo.email + "','" + loginInfo.password + "'").ToArrayAsync();
            
            return Ok(LoginData);
        }

        
    }
}
