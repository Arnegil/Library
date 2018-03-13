using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using PizzaDelivery.Domain.Models.Persons;

namespace PizzaDelivery.Domain.Models.Orders
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        
        public Employee Operator { get; set; }
        
        public Employee Deliveryman { get; set; }

        [Required]
        public Client OrderingClient { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        public OrderState OrderState { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        [StringLength(100)]
        public string CommentToOperator { get; set; }

        [StringLength(100)]
        public string CommentToDeliveryman { get; set; }

        public Collection<OrderPosition> OrderPositions { get; set; }
    }

    public enum OrderState
    {
        Created,
        Cooking,
        WaitingForDeliveryman,
        OnTheWay,
        Paid,
        Cancelled
    }
}
