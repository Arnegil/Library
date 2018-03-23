using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.ViewModel.ViewModels.Ordering;
using PizzaDelivery.ViewModel.Interfaces.Ordering;

namespace PizzaDelivery.Controllers.Ordering
{
    public class PaymentController : Controller
    {
        private readonly IOrderVMService _orderVMService;
        private readonly IPaymentVMService _paymentVMService; 

        public PaymentController(IOrderVMService deliveryVMService, IPaymentVMService paymentVMService)
        {
            if (deliveryVMService == null)
                throw new ArgumentNullException(nameof(deliveryVMService));
            if (paymentVMService == null)
                throw new ArgumentNullException(nameof(paymentVMService));

            _orderVMService = deliveryVMService;
            _paymentVMService = paymentVMService;
        }

        [HttpPost]
        public IActionResult Index(PaymentInfoVM paymentInfo)
        {
            return View("/Views/Ordering/Payment.cshtml", paymentInfo);
        }

        [HttpPost]
        public IActionResult SavePaymentInfo(PaymentInfoVM paymentInfo)
        {
            _paymentVMService.SavePaymentInfo(paymentInfo);
            var newOrder = _orderVMService.BuildNewOrder();
            var model = _orderVMService.CreateOrder(newOrder);

            return View("/Views/Ordering/OrderResult.cshtml", model);
        }
    }
}