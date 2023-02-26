using MediatR;
using MyAwesomeDecks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAwesomeDecks.Application.Queries.GetDecks
{
    public class GetDecksQuery : IRequest<IEnumerable<Deck>>
    {
        public Guid UserId { get; set; }
    }
}
