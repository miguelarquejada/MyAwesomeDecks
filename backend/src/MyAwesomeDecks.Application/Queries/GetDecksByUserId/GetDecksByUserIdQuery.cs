using MediatR;
using MyAwesomeDecks.Domain.Entities;

namespace MyAwesomeDecks.Application.Queries.GetDecks
{
    public class GetDecksByUserIdQuery : IRequest<IEnumerable<Deck>>
    {
        public GetDecksByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}
