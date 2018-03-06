using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Person Person { get; set; }
        public Post Post { get; set; }
    }
}
