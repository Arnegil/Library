using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Models
{
    public class BooksIssuing
    {
        public Guid Id { get; set; }
        public Employee IssuingEmployee { get; set; }
        public Client KeeperClient { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
