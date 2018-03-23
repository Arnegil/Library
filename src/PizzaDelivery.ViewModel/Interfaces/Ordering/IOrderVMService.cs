using System.Collections.Generic;
using System.Text;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.Interfaces.Ordering
{
    public interface IOrderVMService
    {
        OrderVM BuildNewOrder();
        OrderResultVM CreateOrder(OrderVM newOrder);
    }
}