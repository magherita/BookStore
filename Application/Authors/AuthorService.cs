using Application.Models.Authors;
using Domain.Authors;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorCollection _authorCollection;

        public AuthorService(IAuthorCollection authorCollection)
        {
            _authorCollection = authorCollection;
        }

        public async Task<GetAuthorModel> CreateAuthor(
            AddAuthorModel model, 
            CancellationToken cancellationToken = default)
        {
            // validation: ensure model is not null or empty
            if (model == null)
            {
                throw new Exception("Author details are empty");
            }

            // mapping model to the domain entity
            var author = new Author
            {
                Name = model.Name,
                Nationality = model.Nationality,
                Gender = model.Gender
            };

            var result = await _authorCollection.CreateAuthor(author, cancellationToken);

            var response = new GetAuthorModel
            { 
                Id = result.Id,
                Name = result.Name,
                Nationality = result.Nationality
            };

            return response;
        }

        public void DeleteAuthorById(DeleteAuthorModel model)
        {
            if (model == null)
            {
                throw new Exception("Author Id is empty");
            }

            _authorCollection.DeleteAuthorById(model.Id);
        }

        public async Task<GetAuthorModel> GetAuthorById(string authorId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(authorId))
            {
                throw new Exception("Author Id is empty");
            }

            var result = await _authorCollection.GetAuthorById(authorId, cancellationToken);

            if (result == null)
            {
                return new GetAuthorModel();
            }

            var response = new GetAuthorModel
            { 
                Id = result.Id,
                Name = result.Name,
                Gender = result.Gender,
                Nationality = result.Nationality
            };

            return response;
        }

        public async Task<List<GetAuthorModel>> GetAuthors(CancellationToken cancellationToken = default)
        {
            var results = await _authorCollection.GetAuthors(cancellationToken);

            if (results == null || results.Count < 1)
            {
                return new List<GetAuthorModel>();
            }

            var response = new List<GetAuthorModel>();

            // transform from list of authors to list of getauthormodels
            foreach (var result in results)
            {
                var model = new GetAuthorModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    Gender = result.Gender,
                    Nationality = result.Nationality
                };

                response.Add(model);
            }

            return response;
        }

        public void UpdateAuthor(string authorId, UpdateAuthorModel model)
        {
            if (string.IsNullOrWhiteSpace(authorId))
            {
                throw new Exception("Author Id is empty");
            }

            if (model == null)
            {
                throw new Exception("Author details are empty");
            }

            // get current author by id
            var currentAuthor = _authorCollection.GetAuthorById(authorId).Result;

            if (currentAuthor == null)
            {
                throw new Exception("Author does not exist");
            }

            currentAuthor.Name = model.Name;
            currentAuthor.Nationality = model.Nationality;
            currentAuthor.Gender = model.Gender;

            _authorCollection.UpdateAuthor(authorId, currentAuthor);
        }
    }
}
