using Application.Models.Books;
using Domain.Books;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Books
{
    public class BookService : IBookService
    {
        private readonly IBookCollection _bookCollection;

        public BookService(IBookCollection bookCollection)
        {
            _bookCollection = bookCollection;
        }

        public async Task<GetBookModel> CreateBook(
            AddBookModel model, 
            CancellationToken cancellationToken = default)
        {
            // validation: ensure model is not null or empty
            if (model == null)
            {
                throw new Exception("Book details are empty");
            }

            // mapping model to the domain entity
            var book = new Book
            {
               Isbn = model.Isbn,
               Title = model.Title,
               Edition = model.Edition,
               PublishDate = model.PublishDate,
               NumberOfPages = model.NumberOfPages
            };

            var result = await _bookCollection.CreateBook(book, cancellationToken);

            var response = new GetBookModel
            {
                Isbn = result.Isbn,
                Title = result.Title,
                Edition = result.Edition,
                PublishDate = result.PublishDate,
                NumberOfPages = result.NumberOfPages
            };

            return response;
        }

        public void DeleteBookById(DeleteBookModel model)
        {
            if (model == null)
            {
                throw new Exception("Book Id is empty");
            }

            _bookCollection.DeleteBookById(model.Id);
        }

        public async Task<GetBookModel> GetBookById(string bookId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(bookId))
            {
                throw new Exception("Book Id is empty");
            }

            var result = await _bookCollection.GetBookById(bookId, cancellationToken);

            if (result == null)
            {
                return new GetBookModel();
            }

            var response = new GetBookModel
            {
                Isbn = result.Isbn,
                Title = result.Title,
                Edition = result.Edition,
                PublishDate = result.PublishDate,
                NumberOfPages = result.NumberOfPages
            };

            return response;
        }

        public async Task<List<GetBookModel>> GetBooks(CancellationToken cancellationToken = default)
        {
            var results = await _bookCollection.GetBooks(cancellationToken);

            if (results == null || results.Count < 1)
            {
                return new List<GetBookModel>();
            }

            var response = new List<GetBookModel>();

            // transform from list of books to list of getbookmodels
            foreach (var result in results)
            {
                var model = new GetBookModel
                {
                    Isbn = result.Isbn,
                    Title = result.Title,
                    Edition = result.Edition,
                    PublishDate = result.PublishDate,
                    NumberOfPages = result.NumberOfPages
                };

                response.Add(model);
            }

            return response;
        }

        public void UpdateBook(string bookId, UpdateBookModel model)
        {
            if (string.IsNullOrWhiteSpace(bookId))
            {
                throw new Exception("Book Id is empty");
            }

            if (model == null)
            {
                throw new Exception("Book details are empty");
            }

            // get current book by id
            var currentBook = _bookCollection.GetBookById(bookId).Result;

            if (currentBook == null)
            {
                throw new Exception("Book does not exist");
            }

            currentBook.Isbn = model.Isbn;
            currentBook.Title = model.Title;
            currentBook.Edition = model.Edition;
            currentBook.PublishDate = model.PublishDate;
            currentBook.NumberOfPages = model.NumberOfPages;

            _bookCollection.UpdateBook(bookId, currentBook);
        }
    }
}
