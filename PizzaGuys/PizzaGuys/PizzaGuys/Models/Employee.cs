using System;
using System.Collections.Generic;

namespace PizzaGuys.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Order = new HashSet<Order>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int? Address { get; set; }
        public int Phone { get; set; }
        public string VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
