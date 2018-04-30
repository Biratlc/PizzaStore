using System;
using System.Collections.Generic;

namespace PizzaGuys.Models
{
    public partial class Coupon
    {
        public int CouponId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ValidDate { get; set; }

        public Customer Customer { get; set; }
    }
}
