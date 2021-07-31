using Domain.Authors;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Collections
{
    public class AuthorCollection : IAuthorCollection
    {
        private IMongoCollection<Author> _authorCollection;

        public AuthorCollection(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("MongoDb:ConnectionString");
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            var client = new MongoClient(settings);
            var dbName = configuration.GetValue<string>("MongoDb:Database");
            var database = client.GetDatabase(dbName);
            var authorCollectionName = configuration.GetValue<string>("MongoDb:AuthorCollection");

            _authorCollection = database.GetCollection<Author>(authorCollectionName);
        }

        public async Task<Author> CreateAuthor(Author author, CancellationToken cancellationToken = default)
        {
            await _authorCollection.InsertOneAsync(author);

            return author;
        }

        public void DeleteAuthorById(string authorId)
        {
            _authorCollection.DeleteOne(a => a.Id == authorId);
        }

        public async Task<Author> GetAuthorById(string authorId, CancellationToken cancellationToken = default)
        {
            var cursor = await _authorCollection.FindAsync(a => a.Id == authorId);

            var author = await cursor.FirstOrDefaultAsync(cancellationToken);

            return author;
        }

        public async Task<List<Author>> GetAuthors(CancellationToken cancellationToken = default)
        {
            var cursor = await _authorCollection.FindAsync(a => true);

            var authors = await cursor.ToListAsync(cancellationToken);

            return authors;
        }

        public void UpdateAuthor(string authorId, Author author)
        {
            _authorCollection.ReplaceOne(a => a.Id == authorId, author);
        }
    }
}
