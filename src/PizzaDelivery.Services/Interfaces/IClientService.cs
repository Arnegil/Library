using System;
using System.Collections.Generic;
using PizzaDelivery.Domain.Models;

namespace PizzaDelivery.Services.Interfaces
{
    public interface IClientService
    {
        Client GetClientById(Guid clientId);
        void CreateClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
        IEnumerable<Order> GetOrdersOfClient(Guid clientId);
        IEnumerable<Order> GetAciveOrdersOfClient(Guid clientId);
    }
}