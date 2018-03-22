namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class PaymentVM
    {
        public PaymentType PaymentType { get; set; }

        public string CardNumber { get; set; }

        public string CardOwner { get; set; }

        public string DateTo { get; set; }
    }

    public enum PaymentType
    {
        CashToDeliveryman,
        CardToDeliveryman,
        CardOnline
    }
}
