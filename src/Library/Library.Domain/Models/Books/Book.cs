using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Authors { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishYear { get; set; }
    }
}
