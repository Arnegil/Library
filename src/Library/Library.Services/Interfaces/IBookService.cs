using System;
using System.Collections.Generic;
using System.Text;
using Library.Domain.Models;

namespace Library.Services.Interfaces
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
