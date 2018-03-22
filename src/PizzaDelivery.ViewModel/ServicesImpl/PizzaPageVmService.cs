using System;
using System.Linq;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Exensions;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.ServicesImpl
{
    public class PizzaPageVMService : IPizzaPageVMService
    {
        private readonly IPizzaService _pizzaService;
        public int PageSize { get; set; }

        public PizzaPageVMService(IPizzaService pizzaService)
        {
            if (pizzaService == null)
                throw new ArgumentNullException(nameof(pizzaService));

            PageSize = 10;

            _pizzaService = pizzaService;
        }

        public PizzaPageVM GetPizzaPage(int page)
        {
            var allPizzas = _pizzaService.GetAllPizzas();

            var pizzas = allPizzas
                .Take(PageSize * page)
                .Select(x => x.ToPizzaVM())
                .ToList();

            return new PizzaPageVM
            {
                PizzaList = pizzas.Select(pizza => new OrderPositionVM
                {
                    Pizza = pizza,
                    Count = 1
                }).ToList()
            };
        }
    }
}