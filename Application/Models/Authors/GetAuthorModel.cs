using Application.Models.Books;
using Domain.Authors;
using System;
using System.Collections.Generic;

namespace Application.Models.Authors
{
    public class GetAuthorModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public Gender Gender { get; set; }

        public List<GetBookModel> Books { get; set; } = new List<GetBookModel>();
    }
}
