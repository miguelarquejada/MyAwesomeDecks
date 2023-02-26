using MediatR;
using MyAwesomeDecks.Domain.Entities;

namespace MyAwesomeDecks.Application.Queries.GetDecks
{
    public class GetDecksQueryHandler : IRequestHandler<GetDecksQuery, IEnumerable<Deck>>
    {
        public Task<IEnumerable<Deck>> Handle(GetDecksQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
