using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage;

namespace PizzaDelivery.Controllers
{
    public class EditPizzaPageController : Controller
    {
        private readonly IPizzaVMService _pizzaVmService;

        public EditPizzaPageController(IPizzaVMService pizzaVMService)
        {
            _pizzaVmService = pizzaVMService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SavePizza(PizzaVM pizza)
        {
            _pizzaVmService.SavePizza(pizza);

            return RedirectToAction("PizzaSection", "Main");
        }

        public IActionResult DeletePizza(PizzaVM pizza)
        {
            _pizzaVmService.DeletePizza(pizza);

            return RedirectToAction("PizzaSection", "Main");
        }
    }
}
