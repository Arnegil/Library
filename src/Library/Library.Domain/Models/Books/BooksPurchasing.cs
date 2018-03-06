using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Models
{
    public class BooksPurchasing
    {
        public Guid Id { get; set; }
        public Employee CustomerEmployee { get; set; }
        public Company Vendor { get; set; }
        public Book Book { get; set; }
        public Store Store { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Cost { get; set; }
        public int Count { get; set; }
    }
}
