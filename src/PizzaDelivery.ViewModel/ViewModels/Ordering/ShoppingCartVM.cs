using System.Collections.Generic;
using System.Linq;

namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class ShoppingCartVM
    {
        public List<OrderPositionVM> Products { get; set; }

        public decimal SumOrderPrice => Products.Sum(x => x.Count * x.Pizza.Cost);
    }
}
