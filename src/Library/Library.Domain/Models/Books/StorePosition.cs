using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Models
{
    public class StorePosition
    {
        public Guid Id { get; set; }
        public Book Book { get; set; }
        public Store Store { get; set; }
        public int Count { get; set; }
    }
}
