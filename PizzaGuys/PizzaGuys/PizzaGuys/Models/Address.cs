using System;
using System.Collections.Generic;

namespace PizzaGuys.Models
{
    public partial class Address
    {
        public Address()
        {
            Customer = new HashSet<Customer>();
        }

        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string State { get; set; }

        public ICollection<Customer> Customer { get; set; }
    }
}
