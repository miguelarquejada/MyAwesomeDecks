using MediatR;
using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Services;

namespace MyAwesomeDecks.Application.Commands.CardCommands.CreateCard
{
    public class CreateCardHandler : IRequestHandler<CreateCardCommand, Card>
    {
        private readonly ICardService _cardService;

        public CreateCardHandler(ICardService cardService)
        {
            _cardService = cardService;
        }

        public async Task<Card> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var card = new Card(request.Front, request.Back, request.DeckId);
            var result = await _cardService.CreateCardAsync(card);
            return result;
        }
    }
}
