using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaDelivery.Domain.Models.Orders;
using PizzaDelivery.Domain.Models.Persons;

namespace PizzaDelivery.Services.Extensions
{
    public static class PersonExtensions
    {
        public static IEnumerable<Order> GetActiveOrders(this Client client)
        {
            return client.Orders
                .Where(x => x.OrderState != OrderState.Paid && x.OrderState != OrderState.Cancelled);
        }

        public static string GetFullName(this Client client)
        {
            return client.Person.GetFullName();
        }

        public static string GetFullName(this Employee employee)
        {
            return employee.Person.GetFullName();
        }

        public static string GetFullName(this Person person)
        {
            return $"{person.LastName} {person.FirstName.First()} {person.MiddleName.First()}";
        }
    }
}
