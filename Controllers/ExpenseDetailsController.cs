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


    public class ExpenseDetailsController : ControllerBase
    {
        private readonly etrackerContext _context;

        public ExpenseDetailsController(etrackerContext context)
        {
            _context = context;
        }


        // GET: api/Users/email@email.com
        [HttpGet("{user_id}")]
        [Authorize]
        public async Task<IEnumerable<SpExpenseDetails>> GetExpenses(int user_id)
        {
            
            var expenses = await _context.ExpenseDetails.FromSqlRaw("ExpenseDetails " + user_id).ToArrayAsync();
            
            return expenses;
        }

        
    }
}
