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

        [HttpGet]
        public IActionResult Index()
        {
            var model = _deliveryVmService.GetDeliveryInformation();

            return View("/Views/Ordering/DeliveryInfo.cshtml", model);
        }

        [HttpPost]
        public IActionResult SaveDeliveryInformation(DeliveryInfoVM deliveryInfo)
        {
            _deliveryVmService.SaveDeliveryInfo(deliveryInfo);

            return RedirectToAction("Index", "Payment");
        }
    }
}