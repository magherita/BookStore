using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Authors
{
    public interface IAuthorCollection
    {
        Task<List<Author>> GetAuthors(CancellationToken cancellationToken = default);

        Task<Author> GetAuthorById(string authorId, CancellationToken cancellationToken = default);

        Task<Author> CreateAuthor(Author author, CancellationToken cancellationToken = default);

        void UpdateAuthor(string authorId, Author author);

        void DeleteAuthorById(string authorId);
    }
}
