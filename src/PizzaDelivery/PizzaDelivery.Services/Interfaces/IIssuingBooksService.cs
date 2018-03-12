using PizzaDelivery.Domain.Models;

namespace PizzaDelivery.Services.Interfaces
{
    public interface IIssuingBooksService
    {
        void IssueBooks(params BooksIssuing[] booksIssuings);
    }
}