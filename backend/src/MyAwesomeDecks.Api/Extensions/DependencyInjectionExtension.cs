using MyAwesomeDecks.Domain.Repositories;
using MyAwesomeDecks.Domain.Services;
using MyAwesomeDecks.Infrastructure.Repositories;
using MyAwesomeDecks.Infrastructure.Services;

namespace MyAwesomeDecks.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection  AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IDeckService, DeckService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IDeckRepository, DeckRepository>();

            return services;
        }
    }
}
