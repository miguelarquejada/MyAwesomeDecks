using MediatR;
using MyAwesomeDecks.Domain.Entities;
using System.Collections.Generic;

namespace MyAwesomeDecks.Application.Queries.GetDecks
{
    public class GetDecksQueryHandler : IRequestHandler<GetDecksQuery, IEnumerable<Deck>>
    {
        public Task<IEnumerable<Deck>> Handle(GetDecksQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new List<Deck>().AsEnumerable());
        }
    }
}
