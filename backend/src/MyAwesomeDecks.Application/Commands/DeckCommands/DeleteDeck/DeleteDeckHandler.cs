using MediatR;
using MyAwesomeDecks.Domain.Services;

namespace MyAwesomeDecks.Application.Commands.DeckCommands.DeleteDeck
{
    public class DeleteDeckHandler : IRequestHandler<DeleteDeckCommand>
    {
        private readonly IDeckService _deckService;

        public DeleteDeckHandler(IDeckService deckService)
        {
            _deckService = deckService;
        }

        public async Task Handle(DeleteDeckCommand request, CancellationToken cancellationToken)
        {
            await _deckService.DeleteDeckByIdAsync(request.DeckId);
        }
    }
}
