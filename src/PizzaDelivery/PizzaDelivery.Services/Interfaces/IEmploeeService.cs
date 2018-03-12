using System;
using PizzaDelivery.Domain.Models;

namespace PizzaDelivery.Services.Interfaces
{
    public interface IEmploeeService
    {
        Employee GetEmployeeById(Guid id);
        void CreateEmployee(Employee newEmployee);
        void UpdateEmployee(Employee newEmployee);
        void FireEmployee(Employee employee);
    }
}