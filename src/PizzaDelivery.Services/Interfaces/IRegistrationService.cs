using PizzaDelivery.Domain.Models.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDelivery.Services.Interfaces
{
    public interface IRegistrationService
    {
        void RegisterPerson(Person person, Account account);
        void RegisterEmployee(Person newPerson, Account newAccount, string role);
    }
}
