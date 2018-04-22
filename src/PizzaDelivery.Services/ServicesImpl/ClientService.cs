﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Domain;
using PizzaDelivery.Domain.Models.Orders;
using PizzaDelivery.Domain.Models.Persons;
using PizzaDelivery.Services.Interfaces;

namespace PizzaDelivery.Services.ServicesImpl
{
    public class ClientService : IClientService
    {
        private readonly PizzaDeliveryDBContext _context;

        public ClientService(PizzaDeliveryDBContext context)
        {
            _context = context;
        }

        public Client GetClientById(Guid clientId)
        {
            var client = _context.Clients
                .Include(x => x.Person)
                .FirstOrDefault(x => x.Id == clientId);
            return client;
        }

        public Client GetClientByLogin(string login)
        {
            var client = _context.Clients
                .Include(x => x.Person)
                .FirstOrDefault(x => x.Person.Login == login);
            return client;
        }

        public void CreateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(Client client)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersOfClient(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAciveOrdersOfClient(Guid clientId)
        {
            throw new NotImplementedException();
        }
    }
}