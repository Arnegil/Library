using System;
using System.Collections.Generic;
using System.Linq;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Exensions;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.ViewModels.Ordering;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Deliveryman;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Operator;
using OrderState = PizzaDelivery.Domain.Models.Orders.OrderState;

namespace PizzaDelivery.ViewModel.ServicesImpl
{
    internal class PesonalPageVMService : IPesonalPageVMService
    {
        private readonly IClientService _clientService; 
        private readonly IOrderService _orderService; 

        public PesonalPageVMService(IClientService clientService, IOrderService orderService)
        {
            _clientService = clientService;
            _orderService = orderService;
        }

        public PersonalInfoVM GetPersonalInfo(string login)
        {
            var client = _clientService.GetClientByLogin(login);

            return client.ToPersonalInfoVM();
        }

        public void SavePersonalInfo(PersonalInfoVM personalInfo)
        {
            throw new NotImplementedException();
        }

        public OrderHistoryVM GetOrderHistory(Guid clientId)
        {
            var orders = _clientService.GetOrdersOfClient(clientId);

            return new OrderHistoryVM
            {
                OrderList = orders.Select(x => x.ToOrderVM()).ToList()
            };
        }

        public NewOrdersVM GetNewOrders()
        {
            var orders = _orderService.GetNewOrders();

            return new NewOrdersVM
            {
                OrderList = orders
                    .Select(x => x.ToOrderVM())
                    .OrderBy(x => x.CreationDate)
                    .ToList()
            };
        }

        public PersonalOrdersVM GetPersonalOrders(Guid operatorId)
        {
            var orders = _orderService.GetOrdersByOperatorId(operatorId);

            return new PersonalOrdersVM
            {
                OrderList = orders
                    .Select(x => x.ToOrderVM())
                    .OrderBy(x => x.CreationDate)
                    .ToList()
            };
        }

        public void SetOrderOk(OrderPositionVM orderPosition, Guid operatorId)
        {
            _orderService.SetOrderOkStateByOperator(orderPosition.Pizza.Id, operatorId);
        }

        public void SetOrderCancell(OrderPositionVM orderPosition, Guid operatorId)
        {
            _orderService.SetOrderCancelledStateByOperator(orderPosition.Pizza.Id, operatorId);
        }

        public OrdersToDeliveryVM GetOrdersToDelivery()
        {
            var orders = _orderService.GetOrdersToDelivery();

            return new OrdersToDeliveryVM
            {
                OrderList = orders
                    .Select(x => x.ToOrderVM())
                    .OrderBy(x => x.CreationDate)
                    .ToList()
            };
        }

        public void SetOrderDelivered(OrderPositionVM orderPosition)
        {
            _orderService.SetOrderState(orderPosition.Pizza.Id, OrderState.Paid);
        }
    }
}