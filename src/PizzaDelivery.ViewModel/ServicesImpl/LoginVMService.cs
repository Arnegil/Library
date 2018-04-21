using PizzaDelivery.Domain;
using PizzaDelivery.ViewModel.Interfaces.ViewModel;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PizzaDelivery.ViewModel.ServicesImpl
{
    public class LoginVMService : ILoginVMService
    {
        public void LogInUser(LoginVM login)
        {
            using (var db = new PizzaDeliveryDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<PizzaDeliveryDBContext>()))
            {
                var userList = db.Persons;
                var pass = "";
                using (var md5 = MD5.Create())
                {
                    pass = md5.ComputeHash(Encoding.ASCII.GetBytes(login.Password)).ToString();
                }
                if (userList.Find(login.Login).Password.Equals(pass))
                {
                    login.LoggedIn = true;
                    var claims = new List<Claim>
                     {
                        new Claim(ClaimTypes.Name, "Fake User"),
                        new Claim(ClaimTypes.Role,"client")
                    };
                    var identity = new ClaimsIdentity("MyCookieMiddlewareInstance");
                    identity.AddClaims(claims);

                    var principal = new ClaimsPrincipal(identity);
                    
                }
            }
        }
    }
}
