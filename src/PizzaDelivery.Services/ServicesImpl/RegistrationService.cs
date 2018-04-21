using PizzaDelivery.Domain;
using PizzaDelivery.Domain.Models.Persons;
using PizzaDelivery.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDelivery.Services.ServicesImpl
{
    public class RegistrationService : IRegistrationService
    {
        private readonly PizzaDeliveryDBContext _context;
        public RegistrationService(PizzaDeliveryDBContext context)
        {
            _context = context;
        }
        public void RegisterPerson(Person person)
        {
            _context.Persons.Add(person);
        }
    }
}
