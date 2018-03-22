namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class OrderDeliveryVM
    {
        public string ClientName { get; set; }

        public string DeliveryAddress { get; set; }

        public string ClientPhoneNumber { get; set; }

        public string StoreAddress { get; set; }

        public bool ShipmenAtOwnExpense { get; set; }
    }
}
