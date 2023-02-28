using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyAwesomeDecks.Domain.Data;
using MyAwesomeDecks.Infrastructure.Authentication;
using MyAwesomeDecks.Infrastructure.Data.Context;
using MyAwesomeDecks.Infrastructure.Identity;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IApplicationContext, ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssembly(typeof(Program).Assembly);
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
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Set appsettings jwt information to JwtConfig class
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

// Config JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtConfig:Key").Value))
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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
