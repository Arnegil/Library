using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.ViewModel.ViewModels;
using PizzaDelivery.ViewModel.ViewModels.Client;

namespace PizzaDelivery.ViewModel.Interfaces
{
    public interface IOrderVMService
    {
        OrderVM BuildNewOrder(ShoppingCartVM shoppingCart, OrderDeliveryVM orderDelivery);
        OrderResultVM CreateOrder(OrderVM newOrder);
        ViewModels.Operator.OrdersVM GetNewOrdersForOperator();
        ViewModels.Deliveryman.OrdersVM GetNewOrdersForDeliveryman();
    }
}
