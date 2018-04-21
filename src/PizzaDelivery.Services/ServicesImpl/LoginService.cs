using PizzaDelivery.Domain;
using PizzaDelivery.Domain.Models.Persons;
using PizzaDelivery.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PizzaDelivery.Services.ServicesImpl
{
    public class LoginService : ILoginService
    {
        void ILoginService.LogInUser(Person person)
        {
            using (var db = new PizzaDeliveryDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<PizzaDeliveryDBContext>()))
            {
                var userList = db.Persons;
                var pass = "";
                using (var md5 = MD5.Create())
                {
                    pass = md5.ComputeHash(Encoding.ASCII.GetBytes(person.Password)).ToString();
                }
                if (userList.Find(person.Login).Password.Equals(pass))
                {
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
