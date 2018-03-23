using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaDelivery.Domain.Models.Orders
{
    public class DeliveryInfo
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ClientPhoneNumber { get; set; }
    }
}
