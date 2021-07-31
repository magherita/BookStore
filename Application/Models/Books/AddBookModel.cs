using System;

namespace Application.Models.Books
{
    public class AddBookModel
    {
        public string Isbn { get; set; }

        public string Title { get; set; }

        public int NumberOfPages { get; set; }

        public DateTime PublishDate { get; set; }

        public string Edition { get; set; }
    }
}
