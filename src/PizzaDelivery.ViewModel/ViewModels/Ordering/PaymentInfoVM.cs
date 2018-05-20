using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PizzaDelivery.ViewModel.Exensions;

namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class PaymentInfoVM
    {
        [Display(Name = "Тип оплаты")]
        public PaymentType PaymentType { get; set; }

        [Display(Name = "Номер карты")]
        [DataType(DataType.CreditCard)] 
        public string CardNumber { get; set; }

        [Display(Name = "Имя владельца")]
        public string CardOwnerName { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime? DateTo { get; set; }

        [Display(Name = "Количество бонусов:")]
        public decimal Bonuses { get; set; }

        [Display(Name = "Потратить бонусов:")]
        public decimal PayByBonuses { get; set; }

        public bool IsEmpty =>
            string.IsNullOrEmpty(CardNumber) && string.IsNullOrEmpty(CardOwnerName) && !DateTo.HasValue;
    }

    public enum PaymentType
    {
        [Description("Банковская карта")]
        CardOnline,
        [Description("Оплата курьеру")]
        CashToDeliveryman,
        [Description("Оплата банковской картой курьеру")]
        CardToDeliveryman
    }
}
