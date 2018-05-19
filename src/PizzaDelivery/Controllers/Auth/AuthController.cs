using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.ViewModel.Interfaces.ViewModel;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using PizzaDelivery.Models;

namespace PizzaDelivery.Controllers.Auth
{
    public class AuthController : Controller
    {
        private readonly ILoginVMService _loginVMService;

        public AuthController(ILoginVMService loginVMService)
        {
            _loginVMService = loginVMService ?? throw new ArgumentNullException(nameof(loginVMService)); 
        }

        public IActionResult Index()
        {
            return View("/Views/Auth/Auth.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return Index();

            var principal = _loginVMService.LogInUser(model);
            if (principal == null)
                principal = _loginVMService.LogInEmployee(model);
            if (principal == null)
                return Error();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal));
            return RedirectToAction("Index", "Main");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = "Неправильный логин или пароль" });
        }
    }
}
