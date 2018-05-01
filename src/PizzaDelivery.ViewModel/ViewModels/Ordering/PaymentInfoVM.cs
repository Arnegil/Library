using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class PaymentInfoVM
    {
        [Display(Name = "Тип оплаты")]
        public PaymentType PaymentType { get; set; }

        [Display(Name = "Номер карты")]
        public string CardNumber { get; set; }

        [Display(Name = "Имя владельца")]
        public string CardOwnerName { get; set; }

        [Display(Name = "Дата")]
        public DateTime? DateTo { get; set; }

        public bool IsEmpty =>
            string.IsNullOrEmpty(CardNumber) && string.IsNullOrEmpty(CardOwnerName) && !DateTo.HasValue;
    }

    public enum PaymentType
    {
        CardOnline,
        CashToDeliveryman,
        CardToDeliveryman
    }
}
