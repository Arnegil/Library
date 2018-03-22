using System;

namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class OrderVM
    {
        public Guid Id { get; set; }

        public string Number { get; set; }

        public ShoppingCartVM ShoppingCart { get; set; }

        public OrderDeliveryVM OrderDelivery { get; set; }

        public PaymentVM Payment { get; set; }        
    }
}
