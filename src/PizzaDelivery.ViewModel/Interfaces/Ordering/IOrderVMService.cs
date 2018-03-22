using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.ViewModel.ViewModels.Ordering;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Deliveryman;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Operator;

namespace PizzaDelivery.ViewModel.Interfaces.Ordering
{
    public interface IOrderVMService
    {
        OrderVM BuildNewOrder();
        OrderResultVM CreateOrder(OrderVM newOrder);
    }
}
