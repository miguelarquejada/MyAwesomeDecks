using Microsoft.EntityFrameworkCore;
using MyAwesomeDecks.Domain.Data;
using MyAwesomeDecks.Domain.Entities;

namespace MyAwesomeDecks.Infrastructure.Data
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<DeckCard> DeckCard { get; set; }
    }
}
