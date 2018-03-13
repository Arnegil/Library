using System;

namespace PizzaDelivery.ViewModel.ViewModels.Client
{
    public class RegistrationVM
    {
        public string LastName { get; set; }
        
        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }

        public DateTime Birthday { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
    }
}
