using Application.Models.Authors;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authors
{
    public interface IAuthorService
    {
        Task<List<GetAuthorModel>> GetAuthors(CancellationToken cancellationToken = default);

        Task<GetAuthorModel> GetAuthorById(string authorId, CancellationToken cancellationToken = default);

        Task<GetAuthorModel> CreateAuthor(AddAuthorModel model, CancellationToken cancellationToken = default);

        void UpdateAuthor(string authorId, UpdateAuthorModel model);

        void DeleteAuthorById(DeleteAuthorModel model);
    }
}
