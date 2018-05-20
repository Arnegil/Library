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
            return _context.Pizzas.Where(x => x.Id == pizzaId).FirstOrDefault();
        }

        public Pizza GetPizzaByName(string pizzaName)
        {
            return _context.Pizzas.Where(x => x.Name.Equals(pizzaName)).FirstOrDefault();
        }

        public void CreatePizza(Pizza newPizza)
        {
            _context.Add(newPizza);
        }

        public void UpdatePizza(Pizza newPizza)
        {
            if (_context.Pizzas.Where(x => x.Id.Equals(newPizza.Id)).Count() > 0)
                _context.Update(newPizza);
            else
                _context.Add(newPizza);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DeletePizza(Guid pizzaId)
        {
            var pizza = GetPizzaById(pizzaId);
            _context.Pizzas.Remove(pizza);
        }

        public IEnumerable<Pizza> GetAllPizzas()
        {
            var pizzas = _context.Pizzas.AsNoTracking().ToList();

            return pizzas;
        }
    }
}
