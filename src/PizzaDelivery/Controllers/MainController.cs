using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Extensions;
using PizzaDelivery.Models;
using PizzaDelivery.ViewModel;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.Controllers
{
    public class MainController : Controller
    {
        private readonly IPizzaPageVMService _pizzaPageVmService;
        private readonly IShoppingCardVMService _shoppingCardVmService;
        private readonly IPizzaVMService _pizzaVMService;

        public MainController(IPizzaPageVMService pizzaPageVmService, IShoppingCardVMService shoppingCardVmService, IPizzaVMService pizzaVMService)
        {
            if (pizzaPageVmService == null)
                throw new ArgumentNullException(nameof(pizzaPageVmService));
            if (shoppingCardVmService == null)
                throw new ArgumentNullException(nameof(shoppingCardVmService));
            if (pizzaVMService == null)
                throw new ArgumentNullException(nameof(pizzaVMService));

            _pizzaPageVmService = pizzaPageVmService;
            _shoppingCardVmService = shoppingCardVmService;
            _pizzaVMService = pizzaVMService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _pizzaPageVmService.GetPizzaPage(1);

            return View("Main", model);
        }

        [HttpGet]
        public IActionResult PizzaSection()
        {
            var model = _pizzaPageVmService.GetPizzaPage(1);

            return View("Main", model);
        }

        /*[HttpGet]
        public IActionResult PizzaSection(int page)
        {
            var model = _pizzaPageVmService.GetPizzaPage(page);

            return View("Main", model);
        }*/

        [HttpPost]
        public IActionResult AddToShoppingCard(OrderPositionVM orderPosition)
        {
            var shoppingCart = HttpContext.Session.Get<ShoppingCartVM>(SessionKeys.ShoppingCart);
            shoppingCart = _shoppingCardVmService.PutInShoppingCard(shoppingCart, orderPosition);
            HttpContext.Session.Set(SessionKeys.ShoppingCart, shoppingCart);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult AddToShoppingCardAjax([FromBody] OrderPositionVM orderPosition)
        {
            var shoppingCart = HttpContext.Session.Get<ShoppingCartVM>(SessionKeys.ShoppingCart);
            shoppingCart = _shoppingCardVmService.PutInShoppingCard(shoppingCart, orderPosition);
            HttpContext.Session.Set(SessionKeys.ShoppingCart, shoppingCart);

            return Json(new {IsSuccess = true});
        }

        [HttpGet]
        public IActionResult OpenEditPizzaPage(Guid pizzaId)
        {
            var model = _pizzaVMService.GetPizzaById(pizzaId);
            return View("/Views/Main/EditPizza.cshtml", model);
        }

        public IActionResult CreateNewPizzaPage()
        {
            return View("/Views/Main/EditPizza.cshtml", new PizzaVM());
        }

        [Authorize]
        public IActionResult PersonalPage()
        {
            if (HttpContext.User.IsInRole(SecurityRoles.Client))
                return RedirectToAction("Index", "PersonPage");
            if (HttpContext.User.IsInRole(SecurityRoles.Operator))
                return RedirectToAction("IndexOperator", "PersonPage");
            if (HttpContext.User.IsInRole(SecurityRoles.Deliveryman))
                return RedirectToAction("OrdersToDeliveryPage", "PersonPage");

            return Index();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return RedirectToAction("Index","Auth");
        }
        
        [HttpGet]
        public async Task<IActionResult> LoginOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Main");
        }

        public IActionResult RegistrationPage()
        {
            return RedirectToAction("Index", "Registration");
        }

        [Authorize]
        public IActionResult EmployeeRegistration()
        {
            if (HttpContext.User.IsInRole(SecurityRoles.Admin))
                return RedirectToAction("EmployeeRegistration", "Registration");
            return Index();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
