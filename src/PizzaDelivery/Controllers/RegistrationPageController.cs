using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Controllers
{
    public class RegistrationPageController : Controller
    {
        private readonly IRegistrationVMService _registrationVMService;

        public RegistrationPageController(IRegistrationVMService registrationVMService)
        {
            _registrationVMService = registrationVMService ?? throw new ArgumentNullException(nameof(registrationVMService));
        }
        public IActionResult Index()
        {
            return View("/Views/Registration/RegistrationPage.cshtml");
        }

        public IActionResult RegisterPerson(RegistrationVM registration)
        {
            _registrationVMService.RegisterNewClient(registration);
            return RedirectToAction("Main");
        }
    }
}
