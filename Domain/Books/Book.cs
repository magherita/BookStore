using Domain.Authors;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Domain.Books
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ISBN")]
        public string Isbn { get; set; }

        public string Title { get; set; }

        [BsonElement("Pages")]
        public int NumberOfPages { get; set; }

        public DateTime PublishDate { get; set; }

        public string Edition { get; set; }

        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
