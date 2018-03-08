using System;
using System.Collections.Generic;
using Library.Domain.Models;

namespace Library.Services.Interfaces
{
    public interface IClientService
    {
        Client GetClientById(Guid clientId);
        void CreateClient(Person person);
        IEnumerable<BooksIssuing> GetRecievedBooksOfClient(Guid clientId);
        IEnumerable<BooksIssuing> GetKeppedBooksOfClient(Guid clientId);
    }
}