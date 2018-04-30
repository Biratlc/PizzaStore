using System;
using System.Collections.Generic;

namespace PizzaGuys.Models
{
    public partial class Payment
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public int PaymentOption { get; set; }
        public string Status { get; set; }

        public Customer Customer { get; set; }
        public Order Order { get; set; }
        public PaymentOption PaymentOptionNavigation { get; set; }
    }
}
