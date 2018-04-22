using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Domain.Models.Persons
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Login { get; set; }
        
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

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
