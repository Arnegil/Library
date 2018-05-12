using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class OrderVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Номер заказа")]
        public int Number { get; set; }

        [Display(Name = "Состояние заказа")]
        public OrderState OrderState { get; set; }

        [Display(Name = "Дата заказа")]
        public DateTime CreationDate { get; set; }

        public ShoppingCartVM ShoppingCart { get; set; }

        public DeliveryInfoVM DeliveryInfo { get; set; }

        public PaymentInfoVM PaymentInfo { get; set; }     
    }
    
    public enum OrderState
    {
        [Description("Новый")]
        Created,
        [Description("Готовиться")]
        Cooking,
        [Description("Ожидает курьера")]
        WaitingForDeliveryman,
        [Description("В пути")]
        OnTheWay,
        [Description("Оплачен")]
        Paid,
        [Description("Отменён")]
        Cancelled
    }
}
