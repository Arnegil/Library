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
            var model = HttpContext.Session.Get<DeliveryInfoVM>(SessionKeys.DeliveryInfo);
            if (model.IsEmpty)
                model = _deliveryVmService.GetPartOfDeliveryInformation();

            return View("/Views/Ordering/DeliveryInfo.cshtml", model);
        }

        [HttpPost]
        public IActionResult SaveDeliveryInformation(DeliveryInfoVM deliveryInfo)
        {
            HttpContext.Session.Set(SessionKeys.DeliveryInfo, deliveryInfo);

            return RedirectToAction("Index", "Payment");
        }
    }
}