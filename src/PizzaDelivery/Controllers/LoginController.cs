using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.ViewModel.Interfaces.ViewModel;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult LoginUser(LoginVM login)
        {
            _loginVMService.LogInUser(login);
            return RedirectToAction("Main", "Main");
        }
    }
}
