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
        
        public DateTime? Birthday { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
