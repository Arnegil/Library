using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaDelivery.Domain.Models
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
