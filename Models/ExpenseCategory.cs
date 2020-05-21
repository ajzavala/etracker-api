using System;
using System.Collections.Generic;

namespace etracker_api.Models
{
    public partial class ExpenseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public int AlarmThreshold { get; set; }
        public int UserId { get; set; }
    }
}
