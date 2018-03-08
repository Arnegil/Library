using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Domain.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Authors { get; set; }

        [Required]
        [StringLength(50)]
        public string Publisher { get; set; }

        public DateTime PublishYear { get; set; }

        private sealed class IdEqualityComparer : IEqualityComparer<Book>
        {
            public bool Equals(Book x, Book y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id.Equals(y.Id);
            }

            public int GetHashCode(Book obj)
            {
                return obj.Id.GetHashCode();
            }
        }

        public static IEqualityComparer<Book> IdComparer { get; } = new IdEqualityComparer();
    }
}
