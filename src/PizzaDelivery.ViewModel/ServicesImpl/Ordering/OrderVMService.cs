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
        private readonly IClientService _clientService;

        public OrderVMService(IOrderService orderService, IClientService clientService)
        {
            if (orderService == null)
                throw new ArgumentNullException(nameof(orderService));
            if (clientService == null)
                throw new ArgumentNullException(nameof(clientService));

            _orderService = orderService;
            _clientService = clientService;
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

        public OrderResultVM CreateOrder(OrderVM newOrder, string login)
        {
            var order = newOrder.ToOrder();
            var client = _clientService.GetClientByLogin(login);

            if (client == null)
                client = _clientService.CreateTempClient(newOrder.DeliveryInfo.ToDeliveryInfo());

            order.OrderingClient = client;

            if (newOrder.ShoppingCart.Products == null || newOrder.ShoppingCart.Products.Count == 0)
                return new OrderResultVM { SuccessOrdered = false };

            var orderPosotions = newOrder.ShoppingCart.Products.Select(x => x.ToOrderPosition());
            Guid createdOrderId = _orderService.CreateOrder(order, orderPosotions);
            var createdOrder = _orderService.GetOrderById(createdOrderId);
            var createdOrderVM = createdOrder.ToOrderVM();

            if (!client.IsTemp)
                _clientService.AddBonusToClient(client.Id, createdOrder.OrderPositions);

            return new OrderResultVM
            {
                Order = createdOrderVM,
                SuccessOrdered = true
            };
        }
    }
}