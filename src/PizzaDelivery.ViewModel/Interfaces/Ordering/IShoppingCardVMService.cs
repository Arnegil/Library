using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.Interfaces.Ordering
{
    public interface IShoppingCardVMService
    {
        void PutInShoppingCard(OrderPositionVM orderPosition);
        ShoppingCartVM GetShoppingCart();
        void SaveShoppingCart(ShoppingCartVM shoppingCart);
    }
}