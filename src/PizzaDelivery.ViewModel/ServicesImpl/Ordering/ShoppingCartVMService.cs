using System.Linq;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.ServicesImpl.Ordering
{
    internal class ShoppingCartVMService : IShoppingCardVMService
    {
        private readonly Cache _cache;

        public ShoppingCartVMService(Cache cache)
        {
            _cache = cache;
        }

        public void PutInShoppingCard(OrderPositionVM orderPosition)
        {
            var shoppingCart = _cache.ShoppingCartOfCurrentUser;

            var orderedPizza = shoppingCart.Products
                .FirstOrDefault(x => PizzaVM.IdComparer.Equals(x.Pizza, orderPosition.Pizza));

            if (orderedPizza == null)
                shoppingCart.Products.Add(orderPosition);
            else
                orderedPizza.Count += orderPosition.Count;
        }

        public ShoppingCartVM GetShoppingCart()
        {
            return _cache.ShoppingCartOfCurrentUser;
        }

        public void SaveShoppingCart(ShoppingCartVM shoppingCart)
        {
            _cache.ShoppingCartOfCurrentUser.Products = shoppingCart.Products;
        }
    }
}