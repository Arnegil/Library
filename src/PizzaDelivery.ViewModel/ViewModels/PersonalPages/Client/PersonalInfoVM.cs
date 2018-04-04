using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client
{
    public class PersonalInfoVM
    {
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Почта")]
        public string Email { get; set; }

        [Display(Name = "Количество бонусов")]
        public int BonusPoints { get; set; }
    }
}
