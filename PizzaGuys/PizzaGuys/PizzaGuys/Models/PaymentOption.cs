using System;
using System.Collections.Generic;

namespace PizzaGuys.Models
{
    public partial class PaymentOption
    {
        public PaymentOption()
        {
            Payment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string Options { get; set; }
        public int? CardInfoId { get; set; }

        public CardInfo CardInfo { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
