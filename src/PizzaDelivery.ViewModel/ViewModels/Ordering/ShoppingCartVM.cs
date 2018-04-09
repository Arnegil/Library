using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class ShoppingCartVM
    {
        public int Intasd { get; set; }

        public List<OrderPositionVM> Products { get; set; }

        [Display(Name = "Сумма заказа")]
        public decimal SumOrderPrice => Products.Sum(x => x.Count * x.Cost);

        public ShoppingCartVM()
        {
            Products = new List<OrderPositionVM>();
        }
    }
}
