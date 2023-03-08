using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Services;
using System.Collections.Generic;

namespace MyAwesomeDecks.Application.Queries.DeckQueries.GetDecksByUserId
{
    public class GetDecksByUserIdHandler : IRequestHandler<GetDecksByUserIdQuery, IEnumerable<Deck>>
    {
        private readonly IDeckService _deckService;

        public GetDecksByUserIdHandler(IDeckService deckService)
        {
            _deckService = deckService;
        }

        public async Task<IEnumerable<Deck>> Handle(GetDecksByUserIdQuery request, CancellationToken cancellationToken)
        {
            var result = _deckService.GetDecksByUserId(request.UserId).ToList();
            return result;
        }
    }
}
