using System;
using System.Collections.Generic;
using PizzaDelivery.Domain.Models;
using PizzaDelivery.Domain.Models.Orders;

namespace PizzaDelivery.Services.Interfaces
{
    public interface IOrdersService
    {
        Order GetOrderById(Guid orderId);
        void CreateOrder(Order newOrder);
        void UpdateOrder(Order newOrder);
        void DeleteOrder(Order orderId);
        void SetOrderToOperator(Guid orderId, Guid operatorId);
        void SetOrderToDeliveryman(Guid orderId, Guid deliverymanId);
    }
}