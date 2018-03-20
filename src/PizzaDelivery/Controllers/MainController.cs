using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.ViewModels.Client;

namespace PizzaDelivery.Controllers
{
    public class MainController : Controller
    {
        private readonly IPizzaListVMService _pizzaListVmService;
        private readonly IShoppingCardVMService _shoppingCardVmService;

        public MainController()
        {
            _pizzaListVmService = HttpContext.RequestServices.GetService<IPizzaListVMService>();
            _shoppingCardVmService = HttpContext.RequestServices.GetService<IShoppingCardVMService>();
        }

        public IActionResult Index()
        {
            var model = _pizzaListVmService.GetPizzaList(1);

            return View(model);
        }

        public IActionResult PizzaSection()
        {
            var model = _pizzaListVmService.GetPizzaList(1);

            return View(model);
        }

        public IActionResult PizzaSection(int page)
        {
            var model = _pizzaListVmService.GetPizzaList(page);

            return View(model);
        }

        public void AddToShoppingCard(OrderPositionVM orderPosition)
        {
            _shoppingCardVmService.PutInShoppingCard(orderPosition);
        }

        public IActionResult ShoppingCard()
        {
            var model = _shoppingCardVmService.GetShoppingCard();

            return View(model);
        }
    }
}