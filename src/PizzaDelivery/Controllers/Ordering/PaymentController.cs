using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Extensions;
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

        [HttpGet]
        public IActionResult Index()
        {
            var model = HttpContext.Session.Get<PaymentInfoVM>(SessionKeys.PaymentInfo);
            if (model.IsEmpty)
                model = _paymentVMService.GetPartOfPaymentInfo(HttpContext.User.Identity.Name);

            return View("/Views/Ordering/Payment.cshtml", model);
        }

        [HttpPost]
        public IActionResult SavePaymentInfo(PaymentInfoVM paymentInfo)
        {
            /*if (!ModelState.IsValid)
            {
                return Index();
            }*/

            HttpContext.Session.Set(SessionKeys.PaymentInfo, paymentInfo);
            var shoppingCart = HttpContext.Session.Get<ShoppingCartVM>(SessionKeys.ShoppingCart);
            var deliveryInfo = HttpContext.Session.Get<DeliveryInfoVM>(SessionKeys.DeliveryInfo);

            var newOrder = _orderVMService.BuildNewOrder(shoppingCart, deliveryInfo, paymentInfo);
            var model = _orderVMService.CreateOrder(newOrder, HttpContext.User.Identity.Name);
            HttpContext.Session.Set(SessionKeys.ShoppingCart, new ShoppingCartVM());

            return View("/Views/Ordering/OrderResult.cshtml", model);
        }
    }
}