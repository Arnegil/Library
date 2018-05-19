using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using PizzaDelivery.Models;
using PizzaDelivery.ViewModel.Interfaces.ViewModel;

namespace PizzaDelivery.Controllers.Auth
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationVMService _registrationVMService;
        private readonly ILoginVMService _loginVmService;

        public RegistrationController(IRegistrationVMService registrationVMService, ILoginVMService loginVmService)
        {
            _registrationVMService = registrationVMService ?? throw new ArgumentNullException(nameof(registrationVMService));
            _loginVmService = loginVmService ?? throw new ArgumentNullException(nameof(loginVmService));
        }
        
        public IActionResult Index()
        {
            return View("/Views/Registration/Registration.cshtml");
        }

        public IActionResult EmployeeRegistration()
        {
            return View("/Views/Registration/EmployeeRegistration.cshtml");
        }

        [HttpPost]
        public IActionResult EmployeeReRegistration(RegistrationVM registration)
        {
            return View("/Views/Registration/EmployeeRegistration.cshtml", registration);
        }

        [HttpPost]
        public IActionResult ReRegistration(RegistrationVM registration)
        {
            return View("/Views/Registration/Registration.cshtml", registration);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPerson(RegistrationVM registration)
        {
            if (!ModelState.IsValid)
                return ReRegistration(registration);

            _registrationVMService.RegisterNewClient(registration);
            var principal = _loginVmService.LogInUser(new LoginVM {Login = registration.Login, Password = registration.Password});
            if (principal == null)
                return Error();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal));
            return RedirectToAction("Index", "Main");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterEmployee(RegistrationVM registration)
        {
            if (!ModelState.IsValid)
                return EmployeeReRegistration(registration);

            _registrationVMService.RegisterNewEmployee(registration);
            return RedirectToAction("Index","Main");
        }

            public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = "Неправильный логин или пароль" });
        }
    }
}
