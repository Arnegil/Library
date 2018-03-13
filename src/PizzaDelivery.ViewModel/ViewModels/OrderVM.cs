using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.ViewModel.ViewModels.Client;

namespace PizzaDelivery.ViewModel.ViewModels
{
    public class OrderVM
    {
        public Guid Id { get; set; }

        public ShoppingCartVM ShoppingCart { get; set; }

        public OrderDeliveryVM OrderDelivery { get; set; }
    }
}
