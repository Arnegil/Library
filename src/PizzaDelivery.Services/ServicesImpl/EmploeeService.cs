using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Domain;
using PizzaDelivery.Domain.Models.Persons;
using PizzaDelivery.Services.Extensions;
using PizzaDelivery.Services.Interfaces;

namespace PizzaDelivery.Services.ServicesImpl
{
    public class EmploeeService : IEmploeeService
    {
        private readonly PizzaDeliveryDBContext _context;

        public EmploeeService(PizzaDeliveryDBContext context)
        {
            _context = context;
        }
        
        public Employee GetEmployeeById(Guid employeeId)
        {
            var employee = _context.Employees
                .Include(x => x.Person)
                .Include(x => x.Account)
                .FirstOrDefault(x => x.Id == employeeId);
            return employee;
        }

        public Employee GetEmployeeByLogin(string login)
        {
            if (login.IsNullOrEmpty())
                return null;

            var employee = _context.Employees
                .Include(x => x.Person)
                .Include(x => x.Account)
                .FirstOrDefault(x => x.Account.Login.ToLower() == login.ToLower());
            return employee;
        }

        public void CreateEmployee(Employee newEmployee)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee newEmployee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(Employee newEmployee)
        {
            throw new NotImplementedException();
        }
    }
}