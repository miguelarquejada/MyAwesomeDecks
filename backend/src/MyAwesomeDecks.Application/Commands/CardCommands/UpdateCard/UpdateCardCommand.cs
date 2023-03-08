using MediatR;

namespace MyAwesomeDecks.Application.Commands.CardCommands.UpdateCard
{
    public class UpdateCardCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
        public Guid DeckId { get; set; }
    }
}
