using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaDelivery.Domain.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Person Person { get; set; }

        [Required]
        [StringLength(50)]
        public string PostName { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public DateTime? FireDate { get; set; }
    }
}
