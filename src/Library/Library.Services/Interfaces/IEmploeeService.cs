using System;
using Library.Domain.Models;

namespace Library.Services.Interfaces
{
    public interface IEmploeeService
    {
        Employee GetEmployeeById(Guid id);
        void CreateEmployee(Employee newEmployee);
        void UpdateEmployee(Employee newEmployee);
        void FireEmployee(Employee employee);
    }
}