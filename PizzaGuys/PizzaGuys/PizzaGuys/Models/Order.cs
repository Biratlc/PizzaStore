using System;
using System.Collections.Generic;

namespace PizzaGuys.Models
{
    public partial class Order
    {
        public Order()
        {
            Amount = new HashSet<Amount>();
            Payment = new HashSet<Payment>();
            Toppings = new HashSet<Toppings>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int DeliveryStatus { get; set; }
        public int? Topping { get; set; }

        public Customer Customer { get; set; }
        public DeliveryStatus DeliveryStatusNavigation { get; set; }
        public Employee Employee { get; set; }
        public Order OrderNavigation { get; set; }
        public Order InverseOrderNavigation { get; set; }
        public ICollection<Amount> Amount { get; set; }
        public ICollection<Payment> Payment { get; set; }
        public ICollection<Toppings> Toppings { get; set; }
    }
}
