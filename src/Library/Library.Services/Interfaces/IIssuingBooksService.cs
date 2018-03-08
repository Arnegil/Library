using Library.Domain.Models;

namespace Library.Services.Interfaces
{
    public interface IIssuingBooksService
    {
        void IssueBooks(params BooksIssuing[] booksIssuings);
    }
}