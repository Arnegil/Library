using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client
{
    public class PersonalInfoVM
    {
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        
        [Display(Name = "Дата рождения")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Почта")]
        public string Email { get; set; }

        [Display(Name = "Количество бонусов")]
        public decimal BonusPoints { get; set; }
    }
}
