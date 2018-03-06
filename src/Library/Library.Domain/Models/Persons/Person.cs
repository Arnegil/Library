using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
