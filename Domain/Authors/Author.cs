using Domain.Books;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Domain.Authors
{
    public class Author
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public Gender Gender { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }

    public enum Gender
    {
        Female = 1,
        Male = 2,
        Other = 3
    }
}
