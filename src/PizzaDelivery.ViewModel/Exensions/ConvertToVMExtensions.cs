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
            if (pizza == null)
                return null;

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
            if (order == null)
                return null;

            return new OrderVM
            {
                Id = order.Id,
                Number = order.OrderNumber,
                OrderState = (ViewModels.Ordering.OrderState) order.OrderState,
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
            if (orderPosition == null)
                return null;

            return new OrderPositionVM
            { 
                Pizza = orderPosition.Pizza.ToPizzaVM(),
                Count = orderPosition.Count
            };
        }

        public static DeliveryInfoVM ToDeliveryInfoVM(this DeliveryInfo deliveryInfo)
        {
            if (deliveryInfo == null)
                return null;

            return new DeliveryInfoVM
            {
                ClientName = deliveryInfo.ClientName,
                ClientPhoneNumber = deliveryInfo.ClientPhoneNumber,
                DeliveryAddress = deliveryInfo.DeliveryAddress
            };
        }

        public static PaymentInfoVM ToPaymentInfoVM(this PaymentInfo paymentInfo)
        {
            if (paymentInfo == null)
                return null;

            return new PaymentInfoVM
            {
                PaymentType = (ViewModels.Ordering.PaymentType) paymentInfo.PaymentType,
                CardNumber = paymentInfo.CardNumber,
                CardOwnerName = paymentInfo.CardOwnerName,
                DateTo = paymentInfo.DateTo,
                PayByBonuses = paymentInfo.PayByBonuses
            };
        }

        public static PersonalInfoVM ToPersonalInfoVM(this Client client)
        {
            if (client == null)
                return null;

            return new PersonalInfoVM
            {
                Email = client.Person.Email,
                FIO = client.Person.FIO,
                Birthday = client.Person.Birthday,
                PhoneNumber = client.Person.PhoneNumber,
                BonusPoints = client.BonusCount
            };
        }
    }
}
