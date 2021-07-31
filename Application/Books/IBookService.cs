using Application.Models.Books;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Books
{
    public interface IBookService
    {
        Task<List<GetBookModel>> GetBooks(CancellationToken cancellationToken = default);

        Task<GetBookModel> GetBookById(string bookId, CancellationToken cancellationToken = default);

        Task<GetBookModel> CreateBook(AddBookModel model, CancellationToken cancellationToken = default);

        void UpdateBook(string bookId, UpdateBookModel model);

        void DeleteBookById(DeleteBookModel model);
    }
}
