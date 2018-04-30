using System.Collections.Generic;

namespace PizzaGuys.Models
{
    public partial class CardInfo
    {
        public CardInfo()
        {
            PaymentOption = new HashSet<PaymentOption>();
        }

        public int Id { get; set; }
        public int CardTypeId { get; set; }
        public int CardNumber { get; set; }
        public int Ccv { get; set; }

        public CardType CardType { get; set; }
        public ICollection<PaymentOption> PaymentOption { get; set; }
    }
}
