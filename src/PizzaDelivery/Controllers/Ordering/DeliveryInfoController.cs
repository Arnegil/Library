using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.Controllers.Ordering
{
    public class DeliveryInfoController : Controller
    {
        private readonly IDeliveryVMService _deliveryVmService; 
        private readonly IPaymentVMService _paymentVMService; 

        public DeliveryInfoController()
        {
            _deliveryVmService = HttpContext.RequestServices.GetService<IDeliveryVMService>();
            _paymentVMService = HttpContext.RequestServices.GetService<IPaymentVMService>();
        }

        public IActionResult Index(OrderDeliveryVM orderDelivery)
        {
            return View(orderDelivery);
        }

        public IActionResult SaveDeliveryInformation(OrderDeliveryVM orderDelivery)
        {
            _deliveryVmService.SaveDeliveryInfo(orderDelivery);
            var model = _paymentVMService.GetPaymentInfo();

            return View(model);
        }
    }
}