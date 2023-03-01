namespace MyAwesomeDecks.Infrastructure.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base("Usuário ou senha inválidos.")
        {
        }

        public InvalidCredentialsException(string? message) : base(message)
        {
        }
    }
}
