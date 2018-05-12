using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Deliveryman;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Operator;

namespace PizzaDelivery.ViewModel.Interfaces
{
    public interface IPesonalPageVMService
    {
        PersonalInfoVM GetPersonalInfo(string login);
        void SavePersonalInfo(PersonalInfoVM personalInfo);
        OrderHistoryVM GetOrderHistory(Guid clientId);

        NewOrdersVM GetNewOrders();
        PersonalOrdersVM GetPersonalOrders(Guid operatorId);

        OrdersToDeliveryVM GetOrdersToDelivery();
    }
}
