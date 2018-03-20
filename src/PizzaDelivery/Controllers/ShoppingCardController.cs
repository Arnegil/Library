using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.ViewModel.Interfaces;

namespace PizzaDelivery.Controllers
{
    public class ShoppingCardController : Controller
    {
        private readonly IDeliveryVMService _deliveryVmService;
        private readonly IShoppingCardVMService _shoppingCardVmService;

        public ShoppingCardController()
        {
            _deliveryVmService = HttpContext.RequestServices.GetService<IDeliveryVMService>();
            _shoppingCardVmService = HttpContext.RequestServices.GetService<IShoppingCardVMService>();
        }

        public IActionResult Index()
        {
            var model = _shoppingCardVmService.GetShoppingCard();

            return View(model);
        }

        public IActionResult GoToDelivery()
        {
            var model = _deliveryVmService.GetDeliveryInformation();

            return View(model);
        }
    }
}