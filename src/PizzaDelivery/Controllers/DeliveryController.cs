using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.ViewModels;

namespace PizzaDelivery.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly IShoppingCardVMService _shoppingCardVmService;
        private readonly IOrderVMService _orderVmService;

        public DeliveryController()
        {
            _shoppingCardVmService = HttpContext.RequestServices.GetService<IShoppingCardVMService>();
            _orderVmService = HttpContext.RequestServices.GetService<IOrderVMService>();
        }

        public IActionResult SaveOrder(OrderDeliveryVM orderDelivery)
        {
            var shoppingCard = _shoppingCardVmService.GetShoppingCard();
            var newOrder = _orderVmService.BuildNewOrder(shoppingCard, orderDelivery);
            var model = _orderVmService.CreateOrder(newOrder);

            return View(model);
        }
    }
}