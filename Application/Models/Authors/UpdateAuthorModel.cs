using Domain.Authors;
using System;

namespace Application.Models.Authors
{
    public class UpdateAuthorModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public Gender Gender { get; set; }
    }
}
