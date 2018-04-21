using PizzaDelivery.Domain;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PizzaDelivery.ViewModel.ServicesImpl
{
    public class RegistrationVMService : IRegistrationVMService
    {
        public void RegisterNewClient(RegistrationVM registrationVm)
        {
            using (var db = new PizzaDeliveryDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<PizzaDeliveryDBContext>()))
            {
                var RegistrationEncoded = registrationVm;
                using (var md5 = MD5.Create())
                {
                    RegistrationEncoded.Password = md5.ComputeHash(Encoding.ASCII.GetBytes(registrationVm.Password)).ToString();
                }
                db.Add(RegistrationEncoded);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.Write(e);
                }
            }
        }
    }
}
