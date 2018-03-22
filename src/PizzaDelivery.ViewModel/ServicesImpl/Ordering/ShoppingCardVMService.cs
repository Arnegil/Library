using System.Linq;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.ServicesImpl.Ordering
{
    internal class ShoppingCardVMService : IShoppingCardVMService
    {
        private static readonly ShoppingCartVM ShoppingCartOfCurrentUser;

        static ShoppingCardVMService()
        {
            ShoppingCartOfCurrentUser = new ShoppingCartVM();
        }

        public void PutInShoppingCard(OrderPositionVM orderPosition)
        {
            var orderedPizza = ShoppingCartOfCurrentUser.Products
                .FirstOrDefault(x => PizzaVM.IdComparer.Equals(x.Pizza, orderPosition.Pizza));

            if (orderedPizza == null)
                ShoppingCartOfCurrentUser.Products.Add(orderPosition);
            else
                orderedPizza.Count += orderPosition.Count;
        }

        public ShoppingCartVM GetShoppingCard()
        {
            return ShoppingCartOfCurrentUser;
        }

        public void SaveShoppingCard(ShoppingCartVM shoppingCart)
        {
            ShoppingCartOfCurrentUser.Products = shoppingCart.Products;
        }
    }
}