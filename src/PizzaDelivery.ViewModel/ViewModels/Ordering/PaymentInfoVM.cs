using System;

namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class PaymentInfoVM
    {
        public PaymentType PaymentType { get; set; }

        public string CardNumber { get; set; }

        public string CardOwnerName { get; set; }

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
