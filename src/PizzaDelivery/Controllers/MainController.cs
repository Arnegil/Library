using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.Controllers
{
    public class MainController : Controller
    {
        private readonly IPizzaPageVMService _pizzaPageVmService;
        private readonly IShoppingCardVMService _shoppingCardVmService;

        public MainController()
        {
            _pizzaPageVmService = HttpContext.RequestServices.GetService<IPizzaPageVMService>();
            _shoppingCardVmService = HttpContext.RequestServices.GetService<IShoppingCardVMService>();
        }

        public IActionResult Index()
        {
            var model = _pizzaPageVmService.GetPizzaPage(1);

            return View(model);
        }

        public IActionResult PizzaSection()
        {
            var model = _pizzaPageVmService.GetPizzaPage(1);

            return View(model);
        }

        public IActionResult PizzaSection(int page)
        {
            var model = _pizzaPageVmService.GetPizzaPage(page);

            return View(model);
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
            var model = _shoppingCardVmService.GetShoppingCard();

            return View(model);
        }

        public IActionResult PersonalPage()
        {
            return View();
        }
    }
}