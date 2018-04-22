using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.ViewModel.Interfaces;

namespace PizzaDelivery.Controllers
{
    public class PersonPageController : Controller
    {
        private readonly IPesonalPageVMService _pesonalPageVmService;

        public PersonPageController(IPesonalPageVMService pesonalPageVMService)
        {
            if (pesonalPageVMService == null)
                throw new ArgumentNullException(nameof(pesonalPageVMService));

            _pesonalPageVmService = pesonalPageVMService;
        }

        [Authorize(Roles = "client")]
        public IActionResult Index()
        {
            return View("/Views/PersonalPages/ClientPersonalPage.cshtml");
        }

        [Authorize(Roles = "client")]
        public IActionResult PersonalInfoPage()
        {
            var model = _pesonalPageVmService.GetPersonalInfo(HttpContext.User.Identity.Name);

            return View("/Views/PersonalPages/Templates/PersonalInfo.cshtml", model);
        }

        [Authorize(Roles = "client")]
        public IActionResult OrderHistoryPage()
        {
            var model = _pesonalPageVmService.GetOrderHistory();

            return View("/Views/PersonalPages/Templates/OrderHistory.cshtml", model);
        }



        [Authorize(Roles = "operator")]
        public IActionResult NewOrdersPage()
        {
            var model = _pesonalPageVmService.GetNewOrders();
            
            return View("/Views/PersonalPages/Templates/NewOrders.cshtml", model);
        }

        [Authorize(Roles = "operator")]
        public IActionResult PersonalOrdersPage()
        {
            var model = _pesonalPageVmService.GetPersonalOrders();

            return View("/Views/PersonalPages/Templates/PersonalOrders.cshtml", model);
        }



        [Authorize(Roles = "deliveryman")]
        public IActionResult OrdersToDeliveryPage()
        {
            var model = _pesonalPageVmService.GetOrdersToDelivery();

            return View("/Views/PersonalPages/Templates/OrdersToDelivery.cshtml", model);
        }
    }
}