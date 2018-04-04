using System;
using System.Collections.Generic;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.ViewModels.Ordering;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Deliveryman;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Operator;

namespace PizzaDelivery.ViewModel.ServicesImpl
{
    internal class PesonalPageVMService : IPesonalPageVMService
    {
        public PersonalInfoVM GetPersonalInfo()
        {
            return new PersonalInfoVM
            {
                Email = "email@mail.ru",
                FirstName = "Ivan",
                LastName = "Ivanov",
                MiddleName = "Ivanovich",
                Birthday = DateTime.Parse("01.02.1990"),
                PhoneNumber = "323-23-23",
                BonusPoints = 123
            };
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
                                    PizzaName = "Pizza",
                                    PizzaRecipe = "Something",
                                    Cost = 123,
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