using MediatR;
using MyAwesomeDecks.Domain.Entities;

namespace MyAwesomeDecks.Application.Queries.GetDecks
{
    public class GetDecksQuery : IRequest<IEnumerable<Deck>>
    {
        public GetDecksQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}
