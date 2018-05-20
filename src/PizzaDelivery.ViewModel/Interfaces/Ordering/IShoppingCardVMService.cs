using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.Interfaces.Ordering
{
    public interface IShoppingCardVMService
    {
        ShoppingCartVM PutInShoppingCard(ShoppingCartVM shoppingCart, OrderPositionVM orderPosition);
        ShoppingCartVM DeleteFromShoppingCard(ShoppingCartVM shoppingCart, OrderPositionVM orderPosition);
    }
}