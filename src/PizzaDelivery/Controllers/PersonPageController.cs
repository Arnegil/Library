using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.ViewModel.Interfaces;

namespace PizzaDelivery.Controllers
{
    public class PersonPageController : Controller
    {
        private readonly IPesonalPageVMService _pesonalPageVmService;

        public PersonPageController()
        {
            _pesonalPageVmService = HttpContext.RequestServices.GetService<IPesonalPageVMService>();
        }

        public IActionResult Index()
        {
            return PersonalInfoPage();
        }

        public IActionResult PersonalInfoPage()
        {
            var model = _pesonalPageVmService.GetPersonalInfo();

            return View(model);
        }

        public IActionResult OrderHistoryPage()
        {
            var model = _pesonalPageVmService.GetOrderHistory();

            return View(model);
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