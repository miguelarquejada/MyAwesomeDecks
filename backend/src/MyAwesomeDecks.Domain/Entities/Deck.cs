namespace MyAwesomeDecks.Domain.Entities
{
    public class Deck : Entity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
