using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Domain.Models;

namespace Library.Services.Extensions
{
    public static class ClientExtensions
    {
        public static IEnumerable<BooksIssuing> GetKeppedBooks(this Client client)
        {
            return client.RecievedBooks
                .Where(x => !x.ReturnDate.HasValue);
        }
    }
}
