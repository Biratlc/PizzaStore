using System;
using System.Collections.Generic;

namespace PizzaGuys.Models
{
    public partial class Toppings
    {
        public int OrderId { get; set; }
        public int ToppingId { get; set; }

        public Order Order { get; set; }
        public ToppingInfo Topping { get; set; }
    }
}
