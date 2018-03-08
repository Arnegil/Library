using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Domain.Models
{
    public class Store
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Book Book { get; set; }

        public int Count { get; set; }
    }
}
