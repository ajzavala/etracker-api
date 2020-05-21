using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using etracker_api.Models;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;

namespace etracker_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ValidateDataController : ControllerBase
    {
        private readonly etrackerContext _context;

        public ValidateDataController(etrackerContext context)
        {
            _context = context;
        }


        // GET: api/Users/email@email.com
        [HttpGet("{table}/{field}/{data}")]
        [Authorize]
        public async Task<IEnumerable<SpValidateData>> GetData(string table, string field, string data)
        {
            var command = "ValidateData '" + table + "','" + field + "','" + data + "'";

            var validation = await _context.ValidateDatas.FromSqlRaw(command).ToArrayAsync();
            
            return validation;
        }


        
    }
}
