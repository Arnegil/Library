using System;
using System.Collections.Generic;
using PizzaDelivery.Domain.Models.Orders;

namespace PizzaDelivery.Services.Interfaces
{
    public interface IOrderService
    {
        Order GetOrderById(Guid orderId);
        Guid CreateOrder(Order newOrder, IEnumerable<OrderPosition> orderPositions);
        void UpdateOrder(Order newOrder);
        void DeleteOrder(Order orderId);
        void SetOrderToOperator(Guid orderId, Guid operatorId);
        void SetOrderToDeliveryman(Guid orderId, Guid deliverymanId);
        IEnumerable<Order> GetNewOrders();
        IEnumerable<Order> GetOrdersByOperatorId(Guid operatorId);
        IEnumerable<Order> GetOrdersToDelivery();
    }
}