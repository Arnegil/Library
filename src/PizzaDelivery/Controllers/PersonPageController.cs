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
        private readonly IOrderVMService _orderVmService;

        public PersonPageController()
        {
            _orderVmService = HttpContext.RequestServices.GetService<IOrderVMService>();
        }

        public IActionResult Index()
        {
            throw new NotImplementedException();
        }

        public IActionResult ClientPage()
        {
            throw new NotImplementedException();
        }

        public IActionResult OperatorPage()
        {
            var model = _orderVmService.GetNewOrdersForOperator();

            return View(model);
        }

        public IActionResult DeliverymanPage()
        {
            var model = _orderVmService.GetNewOrdersForDeliveryman();

            return View(model);
        }
    }
}