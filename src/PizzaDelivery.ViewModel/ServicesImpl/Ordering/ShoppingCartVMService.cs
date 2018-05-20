using System.Collections.Generic;
using System.Linq;
using PizzaDelivery.Services.Extensions;
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
            if (shoppingCart.Products.IsNullOrEmpty())
                shoppingCart.Products = new List<OrderPositionVM>();

            var orderedPizza = shoppingCart.Products
                .FirstOrDefault(x => x.Pizza.Id == orderPosition.Pizza.Id);

            if (orderedPizza == null)
            {
                var products = shoppingCart.Products.ToList();
                products.Add(orderPosition);
                shoppingCart.Products = products;
            }
            else
                orderedPizza.Count += orderPosition.Count;
            
            return shoppingCart;
        }

        public ShoppingCartVM DeleteFromShoppingCard(ShoppingCartVM shoppingCart, OrderPositionVM orderPosition)
        {
            shoppingCart.Products.RemoveAll(x => x.Pizza.Id == orderPosition.Pizza.Id);
            return shoppingCart;
        }
    }
}