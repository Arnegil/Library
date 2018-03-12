using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaDelivery.Domain.Models
{
    public class BooksIssuing
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Employee IssuingEmployee { get; set; }

        [Required]
        public Client KeeperClient { get; set; }

        [Required]
        public Book IssuedBook { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
