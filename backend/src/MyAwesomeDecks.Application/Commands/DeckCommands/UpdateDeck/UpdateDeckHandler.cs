using MediatR;
using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Services;

namespace MyAwesomeDecks.Application.Commands.DeckCommands.UpdateDeck
{
    public class UpdateDeckHandler : IRequestHandler<UpdateDeckCommand>
    {
        private readonly IDeckService _deckService;

        public UpdateDeckHandler(IDeckService deckService)
        {
            _deckService = deckService;
        }

        public async Task Handle(UpdateDeckCommand request, CancellationToken cancellationToken)
        {
            var deck = new Deck(request.Id, request.Name, request.UserId);
            await _deckService.UpdateDeckAsync(request.Id, deck);
        }
    }
}
