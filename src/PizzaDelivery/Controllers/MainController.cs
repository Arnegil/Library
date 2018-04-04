﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Models;
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
            _shoppingCardVmService.PutInShoppingCard(orderPosition);

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
        
        public IActionResult PersonalPage()
        {
            return RedirectToAction("Index", "PersonPage");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}