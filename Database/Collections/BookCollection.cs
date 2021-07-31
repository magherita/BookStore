using Domain.Books;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Collections
{
    public class BookCollection : IBookCollection
    {
        private IMongoCollection<Book> _bookCollection;

        public BookCollection(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("MongoDb:ConnectionString");
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            var client = new MongoClient(settings);
            var dbName = configuration.GetValue<string>("MongoDb:Database");
            var database = client.GetDatabase(dbName);
            var bookCollectionName = configuration.GetValue<string>("MongoDb:BookCollection");

            _bookCollection = database.GetCollection<Book>(bookCollectionName);
        }

        public async Task<Book> CreateBook(Book book, CancellationToken cancellationToken = default)
        {
            await _bookCollection.InsertOneAsync(book);

            return book;
        }

        public void DeleteBookById(string bookId)
        {
            _bookCollection.DeleteOne(b => b.Id == bookId);
        }

        public async Task<Book> GetBookById(string bookId, CancellationToken cancellationToken = default)
        {
            var cursor = await _bookCollection.FindAsync(b => b.Id == bookId);

            var book = await cursor.FirstOrDefaultAsync(cancellationToken);

            return book;
        }

        public async Task<List<Book>> GetBooks(CancellationToken cancellationToken = default)
        {
            var cursor = await _bookCollection.FindAsync(b => true);

            var books = await cursor.ToListAsync(cancellationToken);

            return books;
        }

        public void UpdateBook(string bookId, Book book)
        {
            _bookCollection.ReplaceOne(b => b.Id == bookId, book);
        }
    }
}
