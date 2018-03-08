using Library.Domain.Models;

namespace Library.Services.Interfaces
{
    public interface IPurchasingBooksService
    {
        void BuyBooks(params BooksPurchasing[] purchasing);
    }
}