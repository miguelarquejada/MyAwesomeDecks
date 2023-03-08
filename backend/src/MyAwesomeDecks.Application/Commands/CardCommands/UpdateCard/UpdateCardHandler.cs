using MediatR;
using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Services;

namespace MyAwesomeDecks.Application.Commands.CardCommands.UpdateCard
{
    public class UpdateCardHandler : IRequestHandler<UpdateCardCommand>
    {
        private readonly ICardService _cardService;

        public UpdateCardHandler(ICardService cardService)
        {
            _cardService = cardService;
        }

        public async Task Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var card = new Card(request.Id, request.Front, request.Back, request.DeckId);
            await _cardService.UpdateCardAsync(card);
        }
    }
}
