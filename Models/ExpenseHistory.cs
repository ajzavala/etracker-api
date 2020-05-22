using System;
using System.Collections.Generic;

namespace etracker_api.Models
{
    public partial class ExpenseHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public int ExpenseCategoryId { get; set; }
        

    }
}
