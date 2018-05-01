using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaDelivery.Domain.Models.Orders;
using PizzaDelivery.Domain.Models.Persons;
using PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage;
using PizzaDelivery.ViewModel.ViewModels.Ordering;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;

namespace PizzaDelivery.ViewModel.Exensions
{
    internal static class ConvertToVMExtensions
    {
        public static PizzaVM ToPizzaVM(this Pizza pizza)
        {
            return new PizzaVM
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Recipe = pizza.Recipe,
                Cost = pizza.Cost
            };
        }

        public static OrderVM ToOrderVM(this Order order)
        {
            return new OrderVM
            {
                Id = order.Id,
                Number = order.OrderNumber,
                ShoppingCart = new ShoppingCartVM
                {
                    Products = order.OrderPositions.Select(ToOrderPositionVM).ToList()
                },
                DeliveryInfo = order.DeliveryInfo.ToDeliveryInfoVM(),
                PaymentInfo = order.PaymentInfo.ToPaymentInfoVM()
            };
        }

        public static OrderPositionVM ToOrderPositionVM(this OrderPosition orderPosition)
        {
            return new OrderPositionVM
            { 
                Pizza = orderPosition.Pizza.ToPizzaVM(),
                Count = orderPosition.Count
            };
        }

        public static DeliveryInfoVM ToDeliveryInfoVM(this DeliveryInfo deliveryInfo)
        {
            return new DeliveryInfoVM
            {
                ClientName = deliveryInfo.ClientName,
                ClientPhoneNumber = deliveryInfo.ClientPhoneNumber,
                DeliveryAddress = deliveryInfo.DeliveryAddress
            };
        }

        public static PaymentInfoVM ToPaymentInfoVM(this PaymentInfo paymentInfo)
        {
            return new PaymentInfoVM
            {
                CardNumber = paymentInfo.CardNumber,
                CardOwnerName = paymentInfo.CardOwnerName,
                DateTo = paymentInfo.DateTo
            };
        }

        public static PersonalInfoVM ToPersonalInfoVM(this Client client)
        {
            return new PersonalInfoVM
            {
                Email = client.Person.Email,
                FirstName = client.Person.FirstName,
                LastName = client.Person.LastName,
                MiddleName = client.Person.MiddleName,
                Birthday = client.Person.Birthday,
                PhoneNumber = client.Person.PhoneNumber,
                BonusPoints = client.BonusCount
            };
        }
    }
}
