using MyAwesomeDecks.Domain.Dto;

namespace MyAwesomeDecks.Domain.Entities
{
    public class Deck : Entity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }

        public ApplicationUserDto User { get; set; }
        public List<Card> Cards { get; set; }
    }
}
