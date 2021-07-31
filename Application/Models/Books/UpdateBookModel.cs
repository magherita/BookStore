using System;

namespace Application.Models.Books
{
    public class UpdateBookModel
    {
        public string Id { get; set; }

        public string Isbn { get; set; }

        public string Title { get; set; }

        public int NumberOfPages { get; set; }

        public DateTime PublishDate { get; set; }

        public string Edition { get; set; }
    }
}
