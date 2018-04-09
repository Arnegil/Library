using System;
using System.Linq;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Exensions;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.ServicesImpl.Ordering
{
    public class OrderVMService : IOrderVMService
    {
        private readonly IOrderService _orderService;

        public OrderVMService(IOrderService orderService)
        {
            if (orderService == null)
                throw new ArgumentNullException(nameof(orderService));

            _orderService = orderService;
        }

        public OrderVM BuildNewOrder(ShoppingCartVM shoppingCart, DeliveryInfoVM deliveryInfo, PaymentInfoVM paymentInfo)
        {
            var vm = new OrderVM
            {
                ShoppingCart = shoppingCart,
                DeliveryInfo = deliveryInfo,
                PaymentInfo = paymentInfo
            };

            return vm;
        }

        public OrderResultVM CreateOrder(OrderVM newOrder)
        {
            var order = newOrder.ToOrder();

            if (newOrder.ShoppingCart.Products == null || newOrder.ShoppingCart.Products.Count == 0)
                return new OrderResultVM { SuccessOrdered = false };

            var orderPosotions = newOrder.ShoppingCart.Products.Select(x => x.ToOrderPosition());
            Guid createdOrderId = _orderService.CreateOrder(order, orderPosotions);
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