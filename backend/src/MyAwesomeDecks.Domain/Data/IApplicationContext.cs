using Microsoft.EntityFrameworkCore;
using MyAwesomeDecks.Domain.Entities;

namespace MyAwesomeDecks.Domain.Data
{
    public interface IApplicationContext : IDisposable
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }
    }
}
