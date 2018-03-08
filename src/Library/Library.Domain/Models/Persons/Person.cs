using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Domain.Models
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }
        
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(20)]
        [DataTypeAttribute(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [DataTypeAttribute(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
