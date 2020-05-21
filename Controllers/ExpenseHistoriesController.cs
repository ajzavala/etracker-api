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
    public class ExpenseHistoriesController : ControllerBase
    {
        private readonly etrackerContext _context;

        public ExpenseHistoriesController(etrackerContext context)
        {
            _context = context;
        }

        // GET: api/ExpenseHistories
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ExpenseHistory>>> GetExpenseHistory()
        {
            return await _context.ExpenseHistory.ToListAsync();
        }

        // GET: api/ExpenseHistories/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ExpenseHistory>> GetExpenseHistory(int id)
        {
            var expenseHistory = await _context.ExpenseHistory.FindAsync(id);

            if (expenseHistory == null)
            {
                return NotFound();
            }

            return expenseHistory;
        }

        // PUT: api/ExpenseHistories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutExpenseHistory(int id, ExpenseHistory expenseHistory)
        {
            if (id != expenseHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(expenseHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseHistoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ExpenseHistories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ExpenseHistory>> PostExpenseHistory(ExpenseHistory expenseHistory)
        {
            _context.ExpenseHistory.Add(expenseHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpenseHistory", new { id = expenseHistory.Id }, expenseHistory);
        }

        // DELETE: api/ExpenseHistories/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<ExpenseHistory>> DeleteExpenseHistory(int id)
        {
            var expenseHistory = await _context.ExpenseHistory.FindAsync(id);
            if (expenseHistory == null)
            {
                return NotFound();
            }

            _context.ExpenseHistory.Remove(expenseHistory);
            await _context.SaveChangesAsync();

            return expenseHistory;
        }

        private bool ExpenseHistoryExists(int id)
        {
            return _context.ExpenseHistory.Any(e => e.Id == id);
        }
    }
}
