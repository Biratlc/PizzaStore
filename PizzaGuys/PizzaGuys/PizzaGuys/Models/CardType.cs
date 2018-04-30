using System;
using System.Collections.Generic;

namespace PizzaGuys.Models
{
    public partial class CardType
    {
        public CardType()
        {
            CardInfo = new HashSet<CardInfo>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<CardInfo> CardInfo { get; set; }
    }
}
