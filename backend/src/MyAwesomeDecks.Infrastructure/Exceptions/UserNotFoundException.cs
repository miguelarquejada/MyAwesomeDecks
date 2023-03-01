namespace MyAwesomeDecks.Infrastructure.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("Usuário não encontrado.")
        {
        }

        public UserNotFoundException(string? message) : base(message)
        {
        }
    }
}
