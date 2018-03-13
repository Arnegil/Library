using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Domain.Models.Orders
{
    public class OrderPosition
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Order Order { get; set; }

        [Required]
        public Pizza Pizza { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
