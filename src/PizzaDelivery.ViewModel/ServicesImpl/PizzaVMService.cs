using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Exensions;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDelivery.ViewModel.ServicesImpl
{
    public class PizzaVMService : IPizzaVMService
    {
        private readonly IPizzaService _pizzaService;

        public PizzaVMService(IPizzaService pizzaService)
        {
            if (pizzaService == null)
                throw new ArgumentNullException(nameof(pizzaService));
            _pizzaService = pizzaService;
        }

        public void CreatePizza(PizzaVM pizza)
        {
            _pizzaService.CreatePizza(pizza.ToPizza());
        }

        public void SavePizza(PizzaVM pizza)
        {
            _pizzaService.UpdatePizza(pizza.ToPizza());
        }

        public void DeletePizza(PizzaVM pizza)
        {
            var pizzaDto = _pizzaService.GetPizzaById(pizza.Id);
            _pizzaService.DeletePizza(pizzaDto.Id);
        }

        public PizzaVM GetPizzaById(Guid pizzaId)
        {
            return _pizzaService.GetPizzaById(pizzaId).ToPizzaVM();
        }
    }
}
