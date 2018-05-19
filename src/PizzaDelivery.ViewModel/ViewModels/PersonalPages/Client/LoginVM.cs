using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client
{
    public class LoginVM
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool LoggedIn { get; set; }
    }
}
