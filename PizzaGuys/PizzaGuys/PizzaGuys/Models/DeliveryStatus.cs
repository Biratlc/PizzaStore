using System;
using System.Collections.Generic;

namespace PizzaGuys.Models
{
    public partial class DeliveryStatus
    {
        public DeliveryStatus()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
