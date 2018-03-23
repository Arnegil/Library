using System;
using PizzaDelivery.Domain.Models.Orders;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Exensions;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.ServicesImpl.Ordering
{
    public class OrderVMService : IOrderVMService
    {
        private readonly IOrderService _orderService;
        private readonly Cache _cache;

        public OrderVMService(IOrderService orderService, Cache cache)
        {
            if (orderService == null)
                throw new ArgumentNullException(nameof(orderService));

            _orderService = orderService;
            _cache = cache;
        }

        public OrderVM BuildNewOrder()
        {
            var vm = new OrderVM
            {
                ShoppingCart = _cache.ShoppingCartOfCurrentUser,
                DeliveryInfo = _cache.OderDeliveryInfoOfCurrentUser,
                PaymentInfo = _cache.PaymentInfoOfCurrentUser
            };

            return vm;
        }

        public OrderResultVM CreateOrder(OrderVM newOrder)
        {
            var order = newOrder.ToOrder();
            Guid createdOrderId = _orderService.CreateOrder(order);
            var createdOrder = _orderService.GetOrderById(createdOrderId);
            var createdOrderVM = createdOrder.ToOrderVM();

            return new OrderResultVM
            {
                Order = createdOrderVM,
                SuccessOrdered = true
            };
        }
    }
}