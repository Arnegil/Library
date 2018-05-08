using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class DeliveryInfoVM
    {
        [Display(Name = "Имя")]
        [Required]
        [MinLength(2)]
        public string ClientName { get; set; }

        [Display(Name = "Адрес доставки")]
        public string DeliveryAddress { get; set; }

        [Display(Name = "Телефон")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ClientPhoneNumber { get; set; }
        
        [Display(Name = "Самовывоз")]
        public bool ShipmenAtOwnExpense { get; set; }

        [Display(Name = "Оставить сообщение оператору")]
        public string CommentToOperator { get; set; }

        public bool IsEmpty => string.IsNullOrEmpty(ClientName) && string.IsNullOrEmpty(DeliveryAddress) &&
                               string.IsNullOrEmpty(ClientPhoneNumber);
    }
}