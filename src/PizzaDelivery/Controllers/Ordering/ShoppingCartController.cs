using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Extensions;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.Controllers.Ordering
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCardVMService _shoppingCardVmService;

        public ShoppingCartController(IShoppingCardVMService shoppingCardVmService)
        {
            if (shoppingCardVmService == null)
                throw new ArgumentNullException(nameof(shoppingCardVmService));
            
            _shoppingCardVmService = shoppingCardVmService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = HttpContext.Session.Get<ShoppingCartVM>(SessionKeys.ShoppingCart);

            return View("/Views/ShoppingCart/ShoppingCart.cshtml", model);
        }

        [HttpPost]
        public IActionResult GoToDelivery(ShoppingCartVM shoppingCart)
        {
            if (!ModelState.IsValid)
            {
                return Index();
            }

            HttpContext.Session.Set(SessionKeys.ShoppingCart, shoppingCart);

            return RedirectToAction("Index", "DeliveryInfo");
        }
    }
}