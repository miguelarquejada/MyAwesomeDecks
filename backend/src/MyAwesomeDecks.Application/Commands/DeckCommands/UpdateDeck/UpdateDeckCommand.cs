using MediatR;
using MyAwesomeDecks.Domain.Entities;

namespace MyAwesomeDecks.Application.Commands.DeckCommands.UpdateDeck
{
    public class UpdateDeckCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
