using System;
using System.Collections.Generic;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Exensions;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage;
using PizzaDelivery.ViewModel.ViewModels.Ordering;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Deliveryman;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Operator;

namespace PizzaDelivery.ViewModel.ServicesImpl
{
    internal class PesonalPageVMService : IPesonalPageVMService
    {
        private readonly IClientService _clientService;

        public PesonalPageVMService(IClientService clientService)
        {
            _clientService = clientService;
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

        public OrderHistoryVM GetOrderHistory()
        {
            return new OrderHistoryVM
            {
                OrderList = new List<OrderVM>
                {
                    new OrderVM
                    {
                        Number = 123,
                        ShoppingCart = new ShoppingCartVM
                        {
                            Products = new List<OrderPositionVM>
                            {
                                new OrderPositionVM
                                {
                                    Pizza = new PizzaVM()
                                    {
                                        Name = "Pizza",
                                        Recipe = "Something",
                                        Cost = 123
                                    },
                                    Count = 2
                                }
                            }
                        }
                    }
                }
            };
        }

        public NewOrdersVM GetNewOrders()
        {
            throw new NotImplementedException();
        }

        public PersonalOrdersVM GetPersonalOrders()
        {
            throw new NotImplementedException();
        }

        public OrdersToDeliveryVM GetOrdersToDelivery()
        {
            throw new NotImplementedException();
        }
    }
}