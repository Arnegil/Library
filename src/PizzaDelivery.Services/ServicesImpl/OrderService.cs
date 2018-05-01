using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Domain;
using PizzaDelivery.Domain.Models.Orders;
using PizzaDelivery.Services.Interfaces;

namespace PizzaDelivery.Services.ServicesImpl
{
    public class OrderService : IOrderService
    {
        private readonly PizzaDeliveryDBContext _context;

        public OrderService(PizzaDeliveryDBContext context)
        {
            _context = context;
        }

        public Order GetOrderById(Guid orderId)
        {
            var order = _context.Orders
                .Include(x => x.OrderingClient)
                .FirstOrDefault(x => x.Id == orderId);

            return order;
        }

        public Guid CreateOrder(Order newOrder, IEnumerable<OrderPosition> orderPositions)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                OrderState = OrderState.Created,
                OrderingClient = newOrder.OrderingClient,
                DeliveryInfo = newOrder.DeliveryInfo,
                PaymentInfo = newOrder.PaymentInfo,
                CommentToOperator = newOrder.CommentToOperator
            };
            order.OrderNumber = GetNextOderNumber();

            foreach (var orderPosition in orderPositions)
            {
                orderPosition.Order = order;
                var pizza = _context.Pizzas.First(x => x.Id == orderPosition.Pizza.Id);
                orderPosition.Pizza = pizza;
                _context.OrderPositions.Add(orderPosition);
            }
            _context.Orders.Add(order);

            _context.SaveChanges();
            return order.Id;
        }

        public void UpdateOrder(Order newOrder)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Order orderId)
        {
            throw new NotImplementedException();
        }

        public void SetOrderToOperator(Guid orderId, Guid operatorId)
        {
            throw new NotImplementedException();
        }

        public void SetOrderToDeliveryman(Guid orderId, Guid deliverymanId)
        {
            throw new NotImplementedException();
        }

        private int GetNextOderNumber()
        {
            if (!_context.Orders.Any())
                return 0;

            int maxNumber = _context.Orders.Max(x => x.OrderNumber);

            return maxNumber + 1;
        }
    }
} 