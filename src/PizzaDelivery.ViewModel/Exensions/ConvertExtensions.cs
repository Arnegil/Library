using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Domain.Models.Orders;
using PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage;

namespace PizzaDelivery.ViewModel.Exensions
{
    internal static class ConvertExtensions
    {
        public static PizzaVM ToPizzaVM(this Pizza pizza)
        {
            return new PizzaVM
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Recipe = pizza.Recipe,
                Cost = pizza.Cost
            };
        }
    }
}
