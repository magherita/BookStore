using Domain.Authors;

namespace Application.Models.Authors
{
    public class AddAuthorModel
    {
        public string Name { get; set; }

        public string Nationality { get; set; }

        public Gender Gender { get; set; }
    }
}
