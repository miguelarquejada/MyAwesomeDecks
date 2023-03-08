using MediatR;
using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Services;

namespace MyAwesomeDecks.Application.Commands.DeckCommands.CreateDeck
{
    public class CreateDeckHandler : IRequestHandler<CreateDeckCommand, Deck>
    {
        private readonly IDeckService _deckService;

        public CreateDeckHandler(IDeckService deckService)
        {
            _deckService = deckService;
        }

        public async Task<Deck> Handle(CreateDeckCommand request, CancellationToken cancellationToken)
        {
            var deck = new Deck(request.Name, request.UserId);
            var result = await _deckService.CreateDeckAsync(deck);
            return result;
        }
    }
}
