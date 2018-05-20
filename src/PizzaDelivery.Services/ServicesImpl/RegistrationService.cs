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

        public void RegisterPerson(Person person, Account account)
        {
            _context.Persons.Add(person);
            _context.Accounts.Add(account);
            _context.Clients.Add(new Client
            {
                Person = person,
                Account = account,
                BonusCount = 0
            });
            _context.SaveChanges();
        }

        public void RegisterEmployee(Person person, Account account, string role)
        {
            _context.Persons.Add(person);
            _context.Accounts.Add(account);
            _context.Employees.Add(new Employee
            {
                Person = person,
                Account = account,
                HireDate = DateTime.Now,
                PostName = RoleParser(role)
            });
            _context.SaveChanges();
        }

        public string RoleParser(string role)
        {
            switch (role)
            {
                case "Оператор":
                    return "Operator";
                case "Курьер":
                    return "Deliveryman";
                default:
                    throw new Exception();
            }
        }
    }
}
