using System.ComponentModel.DataAnnotations;

namespace PizzaGuys.ViewModel
{
    public class RegisterViewModel
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }
    }
}
