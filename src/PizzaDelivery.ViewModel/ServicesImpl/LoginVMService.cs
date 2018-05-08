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
        private readonly IEmploeeService _emploeeService;

        public LoginVMService(IClientService clientService, IEmploeeService emploeeService)
        {
            _clientService = clientService;
            _emploeeService = emploeeService;
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

            if (user.Account.Password.Equals(pass))
            {
                login.LoggedIn = true;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Account.Login),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, SecurityRoles.Client)
                };
                var identity = new ClaimsIdentity(claims, "MyCookieMiddlewareInstance");

                return new ClaimsPrincipal(identity);
            }

            return null;
        }

        public ClaimsPrincipal LogInEmployee(LoginVM login)
        {
            var user = _emploeeService.GetEmployeeByLogin(login.Login);
            if (user == null)
                return null;

            var pass = "";
            using (var md5 = MD5.Create())
            {
                pass = Encoding.UTF8.GetString(md5.ComputeHash(Encoding.UTF8.GetBytes(login.Password)));
            }

            if (user.Account.Password.Equals(pass))
            {
                login.LoggedIn = true;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Account.Login),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, SecurityRoles.Operator)
                };
                var identity = new ClaimsIdentity(claims, "MyCookieMiddlewareInstance");

                return new ClaimsPrincipal(identity);
            }

            return null;
        }
    }
}
