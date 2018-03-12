using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaDelivery.Domain.Models
{
    public class BooksPurchasing
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Employee CustomerEmployee { get; set; }

        [Required]
        public Company Vendor { get; set; }

        [Required]
        public Book Book { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal Cost { get; set; }

        public int Count { get; set; }
    }
}
