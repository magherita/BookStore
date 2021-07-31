using Application.Models.Authors;
using System;
using System.Collections.Generic;

namespace Application.Models.Books
{
    public class GetBookModel
    {
        public string Id { get; set; }

        public string Isbn { get; set; }

        public string Title { get; set; }

        public int NumberOfPages { get; set; }

        public DateTime PublishDate { get; set; }

        public string Edition { get; set; }

        public List<GetAuthorModel> Authors { get; set; } = new List<GetAuthorModel>();
    }
}
