using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client
{
    public class RegistrationVM
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Электронный адрес")]
        public string Email { get; set; }

        [StringLength(200)]
        [Display(Name = "Адрес")]
        public string Address { get; set; }
    }
}
