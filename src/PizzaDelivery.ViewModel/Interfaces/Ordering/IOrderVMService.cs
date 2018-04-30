using System.Collections.Generic;
using System.Text;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.Interfaces.Ordering
{
    public interface IOrderVMService
    {
        OrderVM BuildNewOrder(ShoppingCartVM shoppingCart, DeliveryInfoVM deliveryInfo, PaymentInfoVM paymentInfo);
        OrderResultVM CreateOrder(OrderVM newOrder, string login);
    }
}