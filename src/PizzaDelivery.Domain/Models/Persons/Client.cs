using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using PizzaDelivery.Domain.Models.Orders;

namespace PizzaDelivery.Domain.Models.Persons
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Person Person { get; set; }

        [Required]
        [MinLength(0)]
        public int BonusCount { get; set; }

        [DataType(DataType.CreditCard)]
        public string CardNumber { get; set; }

        [StringLength(20)]
        public string CardOwnerName { get; set; }

        public DateTime? DateTo { get; set; }

        public Collection<Order> Orders { get; set; }

        public bool HaveCardInfo =>
            !string.IsNullOrEmpty(CardNumber) && !string.IsNullOrEmpty(CardOwnerName) && DateTo.HasValue;
    }
}
