namespace MyAwesomeDecks.Domain.Dto
{
    public class ApplicationUserDto
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }

        public ApplicationUserDto()
        {
        }

        public ApplicationUserDto(Guid id, string? email)
        {
            Id = id;
            Email = email;
        }

        public string GetEmailOrEmptyString()
        {
            return Email ?? string.Empty;
        }
    }
}
