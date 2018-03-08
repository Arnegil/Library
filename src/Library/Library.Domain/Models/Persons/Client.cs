using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Domain.Models
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Person Person { get; set; }

        public Collection<BooksIssuing> RecievedBooks { get; set; }
    }
}
