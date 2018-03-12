using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Domain.Models;

namespace PizzaDelivery.Services.Interfaces
{
    public interface IBookService
    {
        Book GetBookById(Guid bookId);
        Book GetBookByAuthorName(string authorName);
        Book GetBookByName(string bookName);
        void CreateBook(Book newBook);
        void UpdateBook(Book newBook);
        int CountOfBooksInStore(Guid bookId);
    }
}
