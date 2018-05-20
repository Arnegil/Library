using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using PizzaDelivery.Domain.Models.Persons;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Exensions;

namespace PizzaDelivery.ViewModel.ServicesImpl
{
    public class RegistrationVMService : IRegistrationVMService
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationVMService(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        public void RegisterNewClient(RegistrationVM registrationVm)
        {
            var newPerson = registrationVm.ToPerson();
            var newAccount = registrationVm.ToAccount();
            newAccount.Type = AccountType.Client;

            using (var md5 = MD5.Create())
            {
                newAccount.Password = Encoding.UTF8.GetString(md5.ComputeHash(Encoding.UTF8.GetBytes(registrationVm.Password)));
            }

            _registrationService.RegisterPerson(newPerson, newAccount);
        }

        public void RegisterNewEmployee(RegistrationVM registrationVM, string role)
        {
            var newPerson = registrationVM.ToPerson();
            var newAccount = registrationVM.ToAccount();
            newAccount.Type = AccountType.Employee;

            using (var md5 = MD5.Create())
            {
                newAccount.Password = Encoding.UTF8.GetString(md5.ComputeHash(Encoding.UTF8.GetBytes(registrationVM.Password)));
            }

            _registrationService.RegisterEmployee(newPerson, newAccount, role);
        }
    }
}
