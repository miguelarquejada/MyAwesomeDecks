using MediatR;
using MyAwesomeDecks.Domain.Entities;

namespace MyAwesomeDecks.Application.Commands.DeckCommands.CreateDeck
{
    public class CreateDeckCommand : IRequest<Deck>
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
