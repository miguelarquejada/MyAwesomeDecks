using MediatR;
using MyAwesomeDecks.Domain.Entities;

namespace MyAwesomeDecks.Application.Commands.CardCommands.CreateCard
{
    public class CreateCardCommand : IRequest<Card>
    {
        public string Front { get; set; }
        public string Back { get; set; }
        public Guid DeckId { get; set; }
    }
}
