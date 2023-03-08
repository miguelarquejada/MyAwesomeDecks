using MediatR;

namespace MyAwesomeDecks.Application.Commands.DeckCommands.DeleteDeck
{
    public class DeleteDeckCommand : IRequest
    {
        public DeleteDeckCommand(Guid deckId)
        {
            DeckId = deckId;
        }

        public Guid DeckId { get; set; }
    }
}
