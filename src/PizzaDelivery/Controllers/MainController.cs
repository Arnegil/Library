using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.Domain.Models.Orders;
using PizzaDelivery.Domain.Models.Persons;
using PizzaDelivery.Extensions;
using PizzaDelivery.Models;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.Interfaces.ViewModel;
using PizzaDelivery.ViewModel.ViewModels.Ordering;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;

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

            return View("Main", model);
        }

        [HttpGet]
        public IActionResult PizzaSection()
        {
            var model = _pizzaPageVmService.GetPizzaPage(1);

            return View("Main", model);
        }

        [HttpGet]
        public IActionResult PizzaSection(int page)
        {
            var model = _pizzaPageVmService.GetPizzaPage(page);

            return View("Main", model);
        }

        [HttpPost]
        public IActionResult AddToShoppingCard(OrderPositionVM orderPosition)
        {
            var shoppingCart = HttpContext.Session.Get<ShoppingCartVM>(SessionKeys.ShoppingCart);
            shoppingCart = _shoppingCardVmService.PutInShoppingCard(shoppingCart, orderPosition);
            HttpContext.Session.Set(SessionKeys.ShoppingCart, shoppingCart);

            return RedirectToAction("Index");
        }

        public IActionResult OpenEditPizzaPage()
        {
            return View();
        }

        public IActionResult CreateNewPizzaPage()
        {
            return View();
        }
        
        [Authorize(Roles = "client")]
        public IActionResult PersonalPage()
        {
            return RedirectToAction("Index", "PersonPage");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return RedirectToAction("Index","Login");
        }

        public IActionResult RegistrationPage()
        {
            return RedirectToAction("Index", "RegistrationPage");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}