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
    public class DeliveryInfoController : Controller
    {
        private readonly IDeliveryVMService _deliveryVmService; 
        private readonly IPaymentVMService _paymentVMService; 

        public DeliveryInfoController(IDeliveryVMService deliveryVmService, IPaymentVMService paymentVmService)
        {
            if (deliveryVmService == null)
                throw new ArgumentNullException(nameof(deliveryVmService));
            if (paymentVmService == null)
                throw new ArgumentNullException(nameof(paymentVmService));

            _deliveryVmService = deliveryVmService;
            _paymentVMService = paymentVmService;
        }

        [HttpPost]
        public IActionResult Index(DeliveryInfoVM deliveryInfo)
        {
            return View("/Views/Ordering/DeliveryInfo.cshtml", deliveryInfo);
        }

        [HttpPost]
        public IActionResult SaveDeliveryInformation(DeliveryInfoVM deliveryInfo)
        {
            _deliveryVmService.SaveDeliveryInfo(deliveryInfo);
            var model = _paymentVMService.GetPaymentInfo();

            return RedirectToAction("Index", "Payment", model);
        }
    }
}