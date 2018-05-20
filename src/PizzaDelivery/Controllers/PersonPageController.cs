using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Extensions;
using PizzaDelivery.ViewModel;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

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

        [Authorize(Roles = SecurityRoles.Client)]
        public IActionResult Index()
        {
            var model = _pesonalPageVmService.GetPersonalInfo(HttpContext.User.Identity.Name);

            return View("/Views/PersonalPages/Templates/PersonalInfo.cshtml", model);
        }

        [Authorize(Roles = SecurityRoles.Client)]
        public IActionResult PersonalInfoPage()
        {
            var model = _pesonalPageVmService.GetPersonalInfo(HttpContext.User.Identity.Name);

            return View("/Views/PersonalPages/Templates/PersonalInfo.cshtml", model);
        }

        [Authorize(Roles = SecurityRoles.Client)]
        public IActionResult OrderHistoryPage()
        {
            var clientId = HttpContext.User.GetId();
            var model = _pesonalPageVmService.GetOrderHistory(clientId);

            return View("/Views/PersonalPages/Templates/OrderHistory.cshtml", model);
        }

        [Authorize(Roles = SecurityRoles.Operator)]
        public IActionResult IndexOperator()
        {
            var model = _pesonalPageVmService.GetNewOrders();
            return View("/Views/PersonalPages/Templates/NewOrders.cshtml", model);
        }

        [Authorize(Roles = SecurityRoles.Operator)]
        public IActionResult NewOrdersPage()
        {
            var model = _pesonalPageVmService.GetNewOrders();
            
            return View("/Views/PersonalPages/Templates/NewOrders.cshtml", model);
        }

        [Authorize(Roles = SecurityRoles.Operator)]
        public IActionResult PersonalOrdersPage()
        {
            var operatorId = HttpContext.User.GetId();
            var model = _pesonalPageVmService.GetPersonalOrders(operatorId);

            return View("/Views/PersonalPages/Templates/PersonalOrders.cshtml", model);
        }

        [HttpPost]
        [Authorize(Roles = SecurityRoles.Operator)]
        public JsonResult OkOrderInOrderNewAjax([FromBody] OrderPositionVM orderPosition)
        {
            var operatorId = HttpContext.User.GetId();
            _pesonalPageVmService.SetOrderOk(orderPosition, operatorId);

            return Json(new { IsSuccess = true });
        }

        [HttpPost]
        [Authorize(Roles = SecurityRoles.Operator)]
        public JsonResult DelOrderInOrderNewAjax([FromBody] OrderPositionVM orderPosition)
        {
            var operatorId = HttpContext.User.GetId();
            _pesonalPageVmService.SetOrderCancell(orderPosition, operatorId);

            return Json(new { IsSuccess = true });
        }



        [Authorize(Roles = SecurityRoles.Deliveryman)]
        public IActionResult OrdersToDeliveryPage()
        {
            var model = _pesonalPageVmService.GetOrdersToDelivery();

            return View("/Views/PersonalPages/Templates/OrdersToDelivery.cshtml", model);
        }

        [HttpPost]
        [Authorize(Roles = SecurityRoles.Deliveryman)]
        public JsonResult ExecuteOrderInOrderToDeliveryAjax([FromBody] OrderPositionVM orderPosition)
        {
            _pesonalPageVmService.SetOrderDelivered(orderPosition);

            return Json(new { IsSuccess = true });
        }
    }
}