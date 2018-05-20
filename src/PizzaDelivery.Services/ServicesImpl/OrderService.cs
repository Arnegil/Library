using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Domain;
using PizzaDelivery.Domain.Models;
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
            var client = _context.Clients.First(x => x.Id == newOrder.OrderingClient.Id);
            _context.DeliveryInfos.Add(newOrder.DeliveryInfo);
            _context.PaymentInfos.Add(newOrder.PaymentInfo);
            
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                OrderState = OrderState.Created,
                OrderingClient = client,
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

        public IEnumerable<Order> GetNewOrders()
        {
            var orders = _context.Orders
                .Include(x => x.OrderingClient)
                .Include(x => x.DeliveryInfo)
                .Include(x => x.PaymentInfo)
                .Include(x => x.OrderPositions).ThenInclude(x => x.Pizza)
                .Where(x => x.OrderState == OrderState.Created)
                .ToList();

            return orders;
        }

        public IEnumerable<Order> GetOrdersByOperatorId(Guid operatorId)
        {
            var stopStates = new[] { OrderState.Created, OrderState.Cancelled, OrderState.Paid };

            var orders = _context.Orders
                .Include(x => x.OrderingClient)
                .Include(x => x.DeliveryInfo)
                .Include(x => x.PaymentInfo)
                .Include(x => x.OrderPositions).ThenInclude(x => x.Pizza)
                .Where(x => !stopStates.Contains(x.OrderState) && x.Operator.Id == operatorId)
                .ToList();

            return orders;
        }

        public IEnumerable<Order> GetOrdersToDelivery()
        {
            var orders = _context.Orders
                .Include(x => x.OrderingClient)
                .Include(x => x.DeliveryInfo)
                .Include(x => x.PaymentInfo)
                .Include(x => x.OrderPositions).ThenInclude(x => x.Pizza)
                .Where(x => x.OrderState == OrderState.WaitingForDeliveryman)
                .ToList();

            return orders;
        }

        public void SetOrderState(Guid orderId, OrderState orderState)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);

            if (order == null)
                return;
            
            order.OrderState = orderState;
            _context.SaveChanges();
        }
        
        public void SetOrderOkStateByOperator(Guid orderId, Guid operatorId)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);
            var operatorEmployee = _context.Employees.FirstOrDefault(x => x.Id == operatorId);

            if (order == null)
                return;

            var deliverymans = _context.Employees.Where(x => x.PostName == PostNames.Deliveryman).ToList();
            var index = new Random().Next(0, deliverymans.Count);

            order.OrderState = OrderState.WaitingForDeliveryman;
            order.Deliveryman = deliverymans[index];
            order.Operator = operatorEmployee;
            _context.SaveChanges();
        }

        public void SetOrderCancelledStateByOperator(Guid orderId, Guid operatorId)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);
            var operatorEmployee = _context.Employees.FirstOrDefault(x => x.Id == operatorId);

            if (order == null)
                return;
            
            order.OrderState = OrderState.Cancelled;
            order.Operator = operatorEmployee;
            _context.SaveChanges();
        }

        private int GetNextOderNumber()
        {
            if (!_context.Orders.Any())
                return 1;

            int maxNumber = _context.Orders.Max(x => x.OrderNumber);

            return maxNumber + 1;
        }
    }
} 