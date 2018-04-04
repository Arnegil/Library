using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class OrderVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Номер заказа")]
        public int Number { get; set; }

        public ShoppingCartVM ShoppingCart { get; set; }

        public DeliveryInfoVM DeliveryInfo { get; set; }

        public PaymentInfoVM PaymentInfo { get; set; }     
    }
}
