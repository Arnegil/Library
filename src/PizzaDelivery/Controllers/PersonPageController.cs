using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Index()
        {
            return View("/Views/PersonalPages/ClientPersonalPage.cshtml");
        }

        public IActionResult PersonalInfoPage()
        {
            var model = _pesonalPageVmService.GetPersonalInfo();

            return View("/Views/PersonalPages/Templates/PersonalInfo.cshtml", model);
        }

        public IActionResult OrderHistoryPage()
        {
            var model = _pesonalPageVmService.GetOrderHistory();

            return View("/Views/PersonalPages/Templates/OrderHistory.cshtml", model);
        }



        public IActionResult NewOrdersPage()
        {
            var model = _pesonalPageVmService.GetNewOrders();

            return View(model);
        }

        public IActionResult PersonalOrdersPage()
        {
            var model = _pesonalPageVmService.GetPersonalOrders();

            return View(model);
        }



        public IActionResult OrdersToDeliveryPage()
        {
            var model = _pesonalPageVmService.GetOrdersToDelivery();

            return View(model);
        }
    }
}