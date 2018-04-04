using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class DeliveryInfoVM
    {
        [Display(Name = "Имя")]
        public string ClientName { get; set; }

        [Display(Name = "Адрес доставки")]
        public string DeliveryAddress { get; set; }

        [Display(Name = "Телефон")]
        public string ClientPhoneNumber { get; set; }

        [Display(Name = "Адрес самовывоза")]
        public string StoreAddress { get; set; }

        [Display(Name = "Самовывоз")]
        public bool ShipmenAtOwnExpense { get; set; }

        [Display(Name = "Оставить сообщение оператору")]
        public string CommentToOperator { get; set; }

        public bool IsEmpty => string.IsNullOrEmpty(ClientName) && string.IsNullOrEmpty(DeliveryAddress) &&
                               string.IsNullOrEmpty(ClientPhoneNumber) && string.IsNullOrEmpty(StoreAddress);
    }
}