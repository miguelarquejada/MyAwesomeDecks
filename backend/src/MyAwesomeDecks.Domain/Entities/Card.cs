namespace MyAwesomeDecks.Domain.Entities
{
    public class Card : Entity
    {
        public string Front { get; set; }
        public string Back { get; set; }

        public Guid DeckId { get; set; }
        public Deck Deck { get; set; }
    }
}
