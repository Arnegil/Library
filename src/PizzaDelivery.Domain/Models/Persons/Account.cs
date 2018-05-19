using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaDelivery.Domain.Models.Persons
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public AccountType Type { get; set; }

        [Required]
        public bool IsTemp { get; set; }
    }

    public enum AccountType
    {
        Client,
        Employee,
        Admin
    }
}
