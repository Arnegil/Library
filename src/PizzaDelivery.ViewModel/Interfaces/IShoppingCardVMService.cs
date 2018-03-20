using PizzaDelivery.Domain.Models.Orders;
using PizzaDelivery.ViewModel.ViewModels.Client;

namespace PizzaDelivery.ViewModel.Interfaces
{
    public interface IShoppingCardVMService
    {
        void PutInShoppingCard(OrderPositionVM orderPosition);
        ShoppingCartVM GetShoppingCard();
    }
}