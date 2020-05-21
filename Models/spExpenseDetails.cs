using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace etracker_api.Models
{
    public class SpExpenseDetails
    {
        public int Id { get; set; }
        public DateTime ExpenseDate {get; set;}
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
    }
}
