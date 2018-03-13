using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Domain.Models.Orders
{
    public class Pizza
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [MinLength(0)]
        public int Cost { get; set; }
    }
}
