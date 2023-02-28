namespace MyAwesomeDecks.Domain.Dto
{
    public class ApplicationUserDto
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }

        public string GetUsernameOrEmptyString()
        {
            return UserName ?? string.Empty;
        }

        public string GetEmailOrEmptyString()
        {
            return Email ?? string.Empty;
        }
    }
}
