using MediatR;
using MyAwesomeDecks.Domain.Services;

namespace MyAwesomeDecks.Application.Commands.CardCommands.DeleteCard
{
    public class DeleteCardHandler : IRequestHandler<DeleteCardCommand>
    {
        private readonly ICardService _cardService;

        public DeleteCardHandler(ICardService cardService)
        {
            _cardService = cardService;
        }

        public async Task Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            await _cardService.DeleteCardByIdAsync(request.Id);
        }
    }
}
