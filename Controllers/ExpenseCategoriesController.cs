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
    public class ExpenseCategoriesController : ControllerBase
    {
        private readonly etrackerContext _context;

        public ExpenseCategoriesController(etrackerContext context)
        {
            _context = context;
        }

        // GET: api/ExpenseCategories
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ExpenseCategory>>> GetExpenseCategory()
        {
            return await _context.ExpenseCategory.ToListAsync();
        }

        // GET: api/ExpenseCategories/5
        [HttpGet("{user_id}")]
        [Authorize]
        public async Task<IEnumerable<ExpenseCategory>> GetExpenseCategory(int user_id)
        {

            var expenseCategory = await _context.ExpenseCategory.FromSqlRaw("select * from expensecategory where user_id='" + user_id + "'").ToArrayAsync();

            return expenseCategory;
        }

        // PUT: api/ExpenseCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutExpenseCategory(int id, ExpenseCategory expenseCategory)
        {
            if (id != expenseCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(expenseCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseCategoryExists(id))
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

        // POST: api/ExpenseCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ExpenseCategory>> PostExpenseCategory(ExpenseCategory expenseCategory)
        {
            _context.ExpenseCategory.Add(expenseCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpenseCategory", new { id = expenseCategory.Id }, expenseCategory);
        }

        // DELETE: api/ExpenseCategories/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<ExpenseCategory>> DeleteExpenseCategory(int id)
        {
            var expenseCategory = await _context.ExpenseCategory.FindAsync(id);
            if (expenseCategory == null)
            {
                return NotFound();
            }

            _context.ExpenseCategory.Remove(expenseCategory);
            await _context.SaveChangesAsync();

            return expenseCategory;
        }

        private bool ExpenseCategoryExists(int id)
        {
            return _context.ExpenseCategory.Any(e => e.Id == id);
        }
    }
}
