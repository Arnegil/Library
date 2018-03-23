using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel
{
    public class Cache
    {
        public ShoppingCartVM ShoppingCartOfCurrentUser { get; }
        public DeliveryInfoVM OderDeliveryInfoOfCurrentUser { get; }
        public PaymentInfoVM PaymentInfoOfCurrentUser { get; }

        public Cache()
        {
            ShoppingCartOfCurrentUser = new ShoppingCartVM();
            OderDeliveryInfoOfCurrentUser = new DeliveryInfoVM();
            PaymentInfoOfCurrentUser = new PaymentInfoVM();
        }
    }
}
