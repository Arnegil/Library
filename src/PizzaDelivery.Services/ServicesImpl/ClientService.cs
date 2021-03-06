﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Domain;
using PizzaDelivery.Domain.Models.Orders;
using PizzaDelivery.Domain.Models.Persons;
using PizzaDelivery.Services.Extensions;
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
                .Include(x => x.Account)
                .FirstOrDefault(x => x.Id == clientId);
            return client;
        }

        public Client GetClientByLogin(string login)
        {
            if (login.IsNullOrEmpty())
                return null;

            var client = _context.Clients
                .Include(x => x.Person)
                .Include(x => x.Account)
                .FirstOrDefault(x => x.Account.Login.ToLower() == login.ToLower());
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
            var orders = _context.Orders
                .Include(x => x.OrderPositions).ThenInclude(x => x.Pizza)
                .Include(x => x.OrderingClient)
                .Where(x => x.OrderingClient.Id == clientId);

            return orders;
        }

        public IEnumerable<Order> GetAciveOrdersOfClient(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public void AddBonusToClient(Guid clientId, Collection<OrderPosition> orderPositions)
        {
            var client = GetClientById(clientId);
            decimal percent = 0.05m;
            decimal bonuses = orderPositions.Sum(x => x.Pizza.Cost * x.Count) * percent;
            client.BonusCount += bonuses;

            _context.SaveChanges();
        }

        public Client CreateTempClient(DeliveryInfo deliveryInfo)
        {
            var newClient = new Client
            {
                Person = new Person
                {
                    FIO = deliveryInfo.ClientName,
                    PhoneNumber = deliveryInfo.ClientPhoneNumber,
                    Address = deliveryInfo.DeliveryAddress
                },
                Account = new Account
                {
                    Login = Guid.NewGuid().ToString(),
                    Password = Guid.NewGuid().ToString(),
                    IsTemp = true
                }
            };

            _context.Add(newClient);
            _context.SaveChanges();

            return newClient;
        }

        public void RemoveBonusFromClient(Guid clientId, decimal paymentInfoPayByBonuses)
        {
            var client = GetClientById(clientId);
            client.BonusCount -= paymentInfoPayByBonuses;

            _context.SaveChanges();
        }
    }
}