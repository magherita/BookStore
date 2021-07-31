using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Books
{
    public interface IBookCollection
    {
        Task<List<Book>> GetBooks(CancellationToken cancellationToken = default);

        Task<Book> GetBookById(string bookId, CancellationToken cancellationToken = default);

        Task<Book> CreateBook(Book book, CancellationToken cancellationToken = default);

        void UpdateBook(string bookId, Book book);

        void DeleteBookById(string bookId);
    }
}
