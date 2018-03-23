using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.Controllers.Ordering
{
    public class ShoppingCartController : Controller
    {
        private readonly IDeliveryVMService _deliveryVmService;
        private readonly IShoppingCardVMService _shoppingCardVmService;

        public ShoppingCartController(IDeliveryVMService deliveryVmService, IShoppingCardVMService shoppingCardVmService)
        {
            if (deliveryVmService == null)
                throw new ArgumentNullException(nameof(deliveryVmService));
            if (shoppingCardVmService == null)
                throw new ArgumentNullException(nameof(shoppingCardVmService));

            _deliveryVmService = deliveryVmService;
            _shoppingCardVmService = shoppingCardVmService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _shoppingCardVmService.GetShoppingCart();

            return View("/Views/Ordering/ShoppingCart.cshtml", model);
        }

        [HttpPost]
        public IActionResult GoToDelivery(ShoppingCartVM shoppingCart)
        {
            _shoppingCardVmService.SaveShoppingCart(shoppingCart);
            var model = _deliveryVmService.GetDeliveryInformation();

            return RedirectToAction("Index", "DeliveryInfo", model);
        }
    }
}