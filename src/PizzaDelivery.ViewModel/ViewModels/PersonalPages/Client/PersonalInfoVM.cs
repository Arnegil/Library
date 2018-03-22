using System;

namespace PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client
{
    public class PersonalInfoVM
    {
        public string LastName { get; set; }
        
        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }

        public DateTime Birthday { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }

        public int BonusPoints { get; set; }
    }
}
