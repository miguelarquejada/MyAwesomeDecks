namespace MyAwesomeDecks.Domain.Entities
{
    public class Card : Entity
    {
        public Card(Guid id, string front, string back, Guid deckId)
        {
            Id = id;
            Front = front;
            Back = back;
            DeckId = deckId;
        }

        public Card(string front, string back, Guid deckId)
        {
            Front = front;
            Back = back;
            DeckId = deckId;
        }

        public Card()
        {
        }

        public string Front { get; set; }
        public string Back { get; set; }
        public Guid DeckId { get; set; }

        public Deck Deck { get; set; }
    }
}
