using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PizzaDelivery.Services.Extensions;

namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class ShoppingCartVM
    {
        public List<OrderPositionVM> Products { get; set; }

        [Display(Name = "Сумма заказа")]
        public decimal SumOrderPrice => Products.IsNullOrEmpty() ? 0 : Products.Sum(x => x.Sum);

        public ShoppingCartVM()
        {
            Products = new List<OrderPositionVM>();
        }
    }
}
