using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaDelivery.Domain.Models.Orders
{
    public class PaymentInfo
    {
        [Key]
        public Guid Id { get; set; }
        
        public PaymentType PaymentType { get; set; }

        [DataType(DataType.CreditCard)]
        public string CardNumber { get; set; }

        [StringLength(20)]
        public string CardOwnerName { get; set; }

        public DateTime? DateTo { get; set; }
    }

    public enum PaymentType
    {
        CardOnline,
        CashToDeliveryman,
        CardToDeliveryman
    }
}
