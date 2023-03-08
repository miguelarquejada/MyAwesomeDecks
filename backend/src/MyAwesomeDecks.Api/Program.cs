using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyAwesomeDecks.Api.Extensions;
using MyAwesomeDecks.Api.Identity;
using MyAwesomeDecks.Api.Middleware;
using MyAwesomeDecks.Api.Swagger;
using MyAwesomeDecks.Application.Queries.DeckQueries.GetDecksByUserId;
using MyAwesomeDecks.Domain.Data;
using MyAwesomeDecks.Domain.Services;
using MyAwesomeDecks.Infrastructure.Authentication;
using MyAwesomeDecks.Infrastructure.Data.Context;
using MyAwesomeDecks.Infrastructure.Identity;
using MyAwesomeDecks.Infrastructure.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAwesomeDecks", Version = "v1" });

    // Adicionar o esquema de segurança JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    // Configurar as opções do esquema de segurança
    c.OperationFilter<AuthenticationRequirementOperationFilter>();
});

builder.Services.AddDbContext<IApplicationContext, ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssembly(typeof(GetDecksByUserIdQuery).Assembly);
});

// User management with identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        //options.Password.RequireDigit = true;
        //options.Password.RequireLowercase = true;
        //options.Password.RequireUppercase = true;
        //options.Password.RequireNonAlphanumeric = true;
        //options.Password.RequiredLength = 8;
    })
    .AddErrorDescriber<IdentityLocalizedErrorDescriber>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Set appsettings jwt information to JwtConfig class
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

// Config JWT
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration.GetSection("JwtConfig:Issuer").Value,
            ValidAudience = builder.Configuration.GetSection("JwtConfig:Audience").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value))
        };
    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Bearer", policy =>
    {
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();
    });
});

builder.Services.AddServices();
builder.Services.AddRepositories();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
