using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.Controllers
{
    public class MainController : Controller
    {
        private readonly IPizzaPageVMService _pizzaPageVmService;
        private readonly IShoppingCardVMService _shoppingCardVmService;

        public MainController(IPizzaPageVMService pizzaPageVmService, IShoppingCardVMService shoppingCardVmService)
        {
            if (pizzaPageVmService == null)
                throw new ArgumentNullException(nameof(pizzaPageVmService));
            if (shoppingCardVmService == null)
                throw new ArgumentNullException(nameof(shoppingCardVmService));

            _pizzaPageVmService = pizzaPageVmService;
            _shoppingCardVmService = shoppingCardVmService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _pizzaPageVmService.GetPizzaPage(1);

            return View("Food/PizzasListPage", model);
        }

        [HttpGet]
        public IActionResult PizzaSection()
        {
            var model = _pizzaPageVmService.GetPizzaPage(1);

            return View("Food/PizzasListPage", model);
        }

        [HttpGet]
        public IActionResult PizzaSection(int page)
        {
            var model = _pizzaPageVmService.GetPizzaPage(page);

            return View("Food/PizzasListPage", model);
        }

        public void AddToShoppingCard(OrderPositionVM orderPosition)
        {
            _shoppingCardVmService.PutInShoppingCard(orderPosition);
        }

        public IActionResult OpenEditPizzaPage()
        {
            return View();
        }

        public IActionResult CreateNewPizzaPage()
        {
            return View();
        }

        public IActionResult ShoppingCard()
        {
            return RedirectToAction("Index", "ShoppingCart");
        }

        public IActionResult PersonalPage()
        {
            return View();
        }
    }
}