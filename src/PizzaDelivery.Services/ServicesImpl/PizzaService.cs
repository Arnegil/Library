using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Domain;
using PizzaDelivery.Domain.Models.Orders;
using PizzaDelivery.Services.Interfaces;

namespace PizzaDelivery.Services.ServicesImpl
{
    public class PizzaService : IPizzaService
    {
        private readonly PizzaDeliveryDBContext _context;

        public PizzaService(PizzaDeliveryDBContext context)
        {
            _context = context;
        }

        public Pizza GetPizzaById(Guid pizzaId)
        {
            throw new NotImplementedException();
        }

        public Pizza GetPizzaByName(string pizzaName)
        {
            throw new NotImplementedException();
        }

        public void CreatePizza(Pizza newPizza)
        {
            throw new NotImplementedException();
        }

        public void UpdatePizza(Pizza newPizza)
        {
            throw new NotImplementedException();
        }

        public void DeletePizza(Guid pizzaId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pizza> GetAllPizzas()
        {
            var pizzas = _context.Pizzas.AsNoTracking().ToList();
            
            return pizzas;
        }
    }
}