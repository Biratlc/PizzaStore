using System;
using System.Collections.Generic;

namespace PizzaGuys.Models
{
    public partial class ToppingInfo
    {
        public ToppingInfo()
        {
            Toppings = new HashSet<Toppings>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amout { get; set; }

        public ICollection<Toppings> Toppings { get; set; }
    }
}
