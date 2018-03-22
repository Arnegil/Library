using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.Interfaces.Ordering
{
    public interface IShoppingCardVMService
    {
        void PutInShoppingCard(OrderPositionVM orderPosition);
        ShoppingCartVM GetShoppingCard();
        void SaveShoppingCard(ShoppingCartVM shoppingCart);
    }
}