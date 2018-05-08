using System;
using PizzaDelivery.Domain.Models;
using PizzaDelivery.Domain.Models.Persons;

namespace PizzaDelivery.Services.Interfaces
{
    public interface IEmploeeService
    {
        Employee GetEmployeeById(Guid employeeId);
        void CreateEmployee(Employee newEmployee);
        void UpdateEmployee(Employee newEmployee);
        void DeleteEmployee(Employee newEmployee);
        Employee GetEmployeeByLogin(string login);
    }
}