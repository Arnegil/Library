namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class DeliveryInfoVM
    {
        public string ClientName { get; set; }

        public string DeliveryAddress { get; set; }

        public string ClientPhoneNumber { get; set; }

        public string StoreAddress { get; set; }

        public bool ShipmenAtOwnExpense { get; set; }

        public string CommentToOperator { get; set; }

        public bool IsEmpty => string.IsNullOrEmpty(ClientName) && string.IsNullOrEmpty(DeliveryAddress) &&
                               string.IsNullOrEmpty(ClientPhoneNumber) && string.IsNullOrEmpty(StoreAddress);
    }
}