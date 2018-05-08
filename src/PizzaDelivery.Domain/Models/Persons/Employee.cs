using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Domain.Models.Persons
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Person Person { get; set; }

        [Required]
        public Account Account { get; set; }

        [Required]
        [StringLength(50)]
        public string PostName { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public DateTime? FireDate { get; set; }
    }
}
