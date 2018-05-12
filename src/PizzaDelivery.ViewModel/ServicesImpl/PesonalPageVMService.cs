using System;
using System.Collections.Generic;
using System.Linq;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Exensions;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Deliveryman;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Operator;

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

            /*return new OrderHistoryVM
            {
                OrderList = new List<OrderVM>
                {
                    new OrderVM
                    {
                        Number = 052,
                        ShoppingCart = new ShoppingCartVM
                        {
                            Products = new List<OrderPositionVM>
                            {
                                new OrderPositionVM
                                {
                                    Pizza = new PizzaVM()
                                    {
                                        Name = "Барбекю",
                                        Recipe = "Пицца с ветчиной, беконом, пепперони, болгарским перцем и томатным соусом для ценителей мясных деликатесов",
                                        Cost = 410
                                    },
                                    Count = 2
                                },
                                new OrderPositionVM
                                {
                                    Pizza = new PizzaVM()
                                    {
                                        Name = "Гавайская",
                                        Recipe = "Волшебное сочетание нежного куриного мяса, ананасов и спелой груши.",
                                        Cost = 335
                                    },
                                    Count = 1
                                }
                            }
                        }
                    },
                    new OrderVM
                    {
                        Number = 058,
                        ShoppingCart = new ShoppingCartVM
                        {
                            Products = new List<OrderPositionVM>
                            {
                                new OrderPositionVM
                                {
                                    Pizza = new PizzaVM()
                                    {
                                        Name = "Карбонара",
                                        Recipe = "Итальянский колорит бекона, сыра, грибов и красного лука",
                                        Cost = 340
                                    },
                                    Count = 3
                                }
                            }
                        }
                    }
                }
            };*/
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
    }
}