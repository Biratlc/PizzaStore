using System;
using System.Collections.Generic;

namespace PizzaGuys.Models
{
    public partial class TotalAmounts
    {
        public int TotalOrdersId { get; set; }
        public int CustomerId { get; set; }
        public bool CouponStatus { get; set; }
        public decimal Totalamounts { get; set; }

        public Customer Customer { get; set; }
    }
}
