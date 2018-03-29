using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaDelivery.Domain.Models.Orders;
using PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

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
                PizzaId = orderPosition.Pizza.Id,
                PizzaName = orderPosition.Pizza.Name,
                PizzaRecipe = orderPosition.Pizza.Recipe,
                Cost = orderPosition.Pizza.Cost,
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
    }
}
