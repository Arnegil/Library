using PizzaDelivery.Domain.Models;

namespace PizzaDelivery.Services.Interfaces
{
    public interface IPurchasingBooksService
    {
        void BuyBooks(params BooksPurchasing[] purchasing);
    }
}