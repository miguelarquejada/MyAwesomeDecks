namespace MyAwesomeDecks.Infrastructure.Exceptions
{
    public class CardNotFoundException : Exception
    {
        public CardNotFoundException() : base("Card não encontrado.")
        {
        }

        public CardNotFoundException(string? message) : base(message)
        {
        }
    }
}
