using PizzaDelivery.Domain;
using PizzaDelivery.ViewModel.Interfaces.ViewModel;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using PizzaDelivery.Services.Interfaces;

namespace PizzaDelivery.ViewModel.ServicesImpl
{
    public class LoginVMService : ILoginVMService
    {
        private readonly IClientService _clientService;

        public LoginVMService(IClientService clientService)
        {
            _clientService = clientService;
        }

        public ClaimsPrincipal LogInUser(LoginVM login)
        {
            var user = _clientService.GetClientByLogin(login.Login);
            if (user == null)
                return null;

            var pass = "";
            using (var md5 = MD5.Create())
            {
                pass = Encoding.UTF8.GetString(md5.ComputeHash(Encoding.UTF8.GetBytes(login.Password)));
            }

            if (user.Person.Password.Equals(pass))
            {
                login.LoggedIn = true;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Person.Login),
                    new Claim(ClaimTypes.Role, "client")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieMiddlewareInstance");

                return new ClaimsPrincipal(identity);
            }

            return null;
        }
    }
}
