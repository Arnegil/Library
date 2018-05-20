using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NuGet.Packaging;
using PizzaDelivery.Domain.Models.Orders;
using PizzaDelivery.Domain.Models.Persons;
using PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage;
using PizzaDelivery.ViewModel.ViewModels.Ordering;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using PaymentType = PizzaDelivery.Domain.Models.Orders.PaymentType;

namespace PizzaDelivery.ViewModel.Exensions
{
    internal static class ConvertToModelExtensions
    {
        public static Pizza ToPizza(this PizzaVM pizza)
        {
            return new Pizza
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Recipe = pizza.Recipe,
                Cost = pizza.Cost
            };
        }

        public static Order ToOrder(this OrderVM order)
        {
            var model = new Order
            {
                DeliveryInfo = order.DeliveryInfo.ToDeliveryInfo(),
                PaymentInfo = order.PaymentInfo.ToPaymentInfo()
            };
            model.CommentToOperator = order.DeliveryInfo.CommentToOperator;

            return model;
        }

        public static OrderPosition ToOrderPosition(this OrderPositionVM orderPosition)
        {
            return new OrderPosition
            {
                Pizza = orderPosition.Pizza.ToPizza(),
                Count = orderPosition.Count
            };
        }

        public static DeliveryInfo ToDeliveryInfo(this DeliveryInfoVM deliveryInfo)
        {
            return new DeliveryInfo
            {
                ClientName = deliveryInfo.ClientName,
                ClientPhoneNumber = deliveryInfo.ClientPhoneNumber,
                DeliveryAddress = deliveryInfo.DeliveryAddress
            };
        }

        public static PaymentInfo ToPaymentInfo(this PaymentInfoVM paymentInfo)
        {
            return new PaymentInfo
            {
                PaymentType = (PaymentType) paymentInfo.PaymentType,
                CardNumber = paymentInfo.CardNumber,
                CardOwnerName = paymentInfo.CardOwnerName,
                DateTo = paymentInfo.DateTo,
                PayByBonuses = paymentInfo.PayByBonuses
            };
        }

        public static Person ToPerson(this RegistrationVM registration)
        {
            return new Person
            {
                Address = registration.Address,
                Birthday = registration.Birthday,
                Email = registration.Email,
                FIO = registration.FIO,
                PhoneNumber = registration.PhoneNumber
            };
        }

        public static Account ToAccount(this RegistrationVM registration)
        {
            return new Account
            {
                Login = registration.Login
            };
        }
    }
}
