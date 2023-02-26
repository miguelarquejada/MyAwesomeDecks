namespace MyAwesomeDecks.Domain.Entities
{
    public class DeckCard : Entity
    {
        public Deck Deck { get; set; }
        public Card Card { get; set; }
    }
}
