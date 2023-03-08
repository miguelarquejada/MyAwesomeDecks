using MyAwesomeDecks.Domain.Data;
using MyAwesomeDecks.Domain.Dto;

namespace MyAwesomeDecks.Domain.Entities
{
    public class Deck : Entity
    {
        public Deck(Guid id, string name, Guid userId)
        {
            Id = id;
            Name = name;
            UserId = userId;
        }

        public Deck(string name, Guid userId)
        {
            Name = name;
            UserId = userId;
        }

        public Deck()
        {
        }

        public string Name { get; set; }
        public Guid UserId { get; set; }

        public List<Card> Cards { get; set; }
    }
}
