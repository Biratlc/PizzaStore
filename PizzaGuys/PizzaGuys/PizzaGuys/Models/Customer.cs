using System.Collections.Generic;

namespace PizzaGuys.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Coupon = new HashSet<Coupon>();
            Order = new HashSet<Order>();
            Payment = new HashSet<Payment>();
            TotalAmounts = new HashSet<TotalAmounts>();
        }

        public int CustomerId { get; set; }
        public int? Address { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Address AddressNavigation { get; set; }
        public ICollection<Coupon> Coupon { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<Payment> Payment { get; set; }
        public ICollection<TotalAmounts> TotalAmounts { get; set; }
    }
}
