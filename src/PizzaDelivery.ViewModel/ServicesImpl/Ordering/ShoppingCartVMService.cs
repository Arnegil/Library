using System.Linq;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.ServicesImpl.Ordering
{
    internal class ShoppingCartVMService : IShoppingCardVMService
    {
        public ShoppingCartVMService()
        { }

        public ShoppingCartVM PutInShoppingCard(ShoppingCartVM shoppingCart, OrderPositionVM orderPosition)
        {
            if (orderPosition.Count <= 0)
                return shoppingCart;

            var orderedPizza = shoppingCart.Products
                .FirstOrDefault(x => x.PizzaId == orderPosition.PizzaId);

            if (orderedPizza == null)
            {
                var products = shoppingCart.Products.ToList();
                products.Add(orderPosition);
                shoppingCart.Products = products;
            }
            else
                orderedPizza.Count += orderPosition.Count;

            shoppingCart.Intasd = 123;

            return shoppingCart;
        }
    }
}