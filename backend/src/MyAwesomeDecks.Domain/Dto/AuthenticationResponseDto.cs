namespace MyAwesomeDecks.Domain.Dto
{
    public class AuthenticationResponseDto
    {
        public ApplicationUserDto User { get; set; }
        public string Token { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public AuthenticationResponseDto()
        {
        }

        public AuthenticationResponseDto(ApplicationUserDto user, string token)
        {
            User = user;
            Token = token;
        }
    }
}
