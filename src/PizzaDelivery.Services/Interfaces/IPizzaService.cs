using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Domain.Models;

namespace PizzaDelivery.Services.Interfaces
{
    public interface IPizzaService
    {
        Pizza GetPizzaById(Guid pizzaId);
        Pizza GetPizzaByName(string pizzaName);
        void CreatePizza(Pizza newPizza);
        void UpdatePizza(Pizza newPizza);
        void DeletePizza(Guid pizzaId);
    }
}
