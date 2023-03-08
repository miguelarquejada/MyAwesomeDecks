namespace MyAwesomeDecks.Infrastructure.Exceptions
{
    public class DeckNotFoundException : Exception
    {
        public DeckNotFoundException() : base("Deck não encontrado.")
        {
        }

        public DeckNotFoundException(string? message) : base(message)
        {
        }
    }
}
