using System;
using System.Collections.Generic;

namespace PizzaGuys.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Employee = new HashSet<Employee>();
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public string LicensePlateNumber { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
