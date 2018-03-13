using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Remotion.Linq.Clauses.Expressions;

namespace PizzaDelivery.Domain.Models
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

        public Collection<Order> Orders { get; set; }
    }
}
