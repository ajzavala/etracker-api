using System;
using System.Collections.Generic;

namespace etracker_api.Models
{
    public partial class ExpenseDetail
    {
        public DateTime ExpenseDate { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
