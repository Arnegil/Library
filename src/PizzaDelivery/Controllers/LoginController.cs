using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.ViewModel.Interfaces.ViewModel;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using PizzaDelivery.Models;

namespace PizzaDelivery.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginVMService _loginVMService;

        public LoginController(ILoginVMService loginVMService)
        {
            _loginVMService = loginVMService ?? throw new ArgumentNullException(nameof(loginVMService)); 
        }

        public IActionResult Index()
        {
            return View("/Views/Login/Login.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginVM model)
        {
            var principal = _loginVMService.LogInUser(model);
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
