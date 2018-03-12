using System;
using System.Collections.Generic;
using PizzaDelivery.Domain.Models;

namespace PizzaDelivery.Services.Interfaces
{
    public interface IClientService
    {
        Client GetClientById(Guid clientId);
        void CreateClient(Person person);
        IEnumerable<BooksIssuing> GetRecievedBooksOfClient(Guid clientId);
        IEnumerable<BooksIssuing> GetKeppedBooksOfClient(Guid clientId);
    }
}