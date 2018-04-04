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

        public DeliveryInfoController(IDeliveryVMService deliveryVmService)
        {
            if (deliveryVmService == null)
                throw new ArgumentNullException(nameof(deliveryVmService));

            _deliveryVmService = deliveryVmService;
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