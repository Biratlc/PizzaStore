using System;
using System.Collections.Generic;

namespace PizzaGuys.Models
{
    public partial class Amount
    {
        public int AmountId { get; set; }
        public string Description { get; set; }
        public int OrderId { get; set; }
        public decimal Amount1 { get; set; }

        public Order Order { get; set; }
    }
}
