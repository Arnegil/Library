using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.ViewModel.ViewModels.Ordering;
using PizzaDelivery.ViewModel.Interfaces.Ordering;

namespace PizzaDelivery.Controllers.Ordering
{
    public class PaymentController : Controller
    {
        private readonly IOrderVMService _orderVmService;
        private readonly IPaymentVMService _paymentVMService; 

        public PaymentController()
        {
            _orderVmService = HttpContext.RequestServices.GetService<IOrderVMService>();
            _paymentVMService = HttpContext.RequestServices.GetService<IPaymentVMService>();
        }

        public IActionResult Index(PaymentVM payment)
        {
            return View(payment);
        }

        public IActionResult SavePaymentInfo(PaymentVM payment)
        {
            _paymentVMService.SavePaymentInfo(payment);
            var newOrder = _orderVmService.BuildNewOrder();
            var model = _orderVmService.CreateOrder(newOrder);

            return View(model);
        }
    }
}