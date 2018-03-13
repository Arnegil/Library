using System.Collections.Generic;
using System.Linq;

namespace PizzaDelivery.ViewModel.ViewModels.Client
{
    public class ShoppingCartVM
    {
        public List<OrderPositionVM> Products { get; set; }

        public decimal OrderPrice => Products.Sum(x => x.Count * x.Pizza.Cost);
    }
}
