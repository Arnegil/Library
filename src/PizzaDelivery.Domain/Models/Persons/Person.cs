﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Domain.Models.Persons
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FIO { get; set; }
        
        public DateTime? Birthday { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Address { get; set; }
    }
}
