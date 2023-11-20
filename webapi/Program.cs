using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using webapi.Context;
using webapi.Interfaces;
using webapi.Middleware;
using webapi.Models;
using webapi.Repositories;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Injection db contextu i ustawienie connection string żeby czytał z appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExchangeBoardContext"));
});
// Swagger do sprawdzania endpointów api
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// CORS policy żeby się dało podłączyć z innego url https://localhost:4200 niż ma backend
string frontendCorsPolicy = "frontend";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: frontendCorsPolicy, policy =>
    {
        policy.WithOrigins("https://localhost:4200")
        .AllowAnyMethod().AllowAnyHeader();
    });
});
// inject mojego ITokenService do kontrolerów które mają takie pole w konstruktorze
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
builder.Services.AddScoped<IMatchesRepository, MatchesRepository>();
builder.Services.AddScoped<IMatchingAlgorithmService, MatchingAlgorithmService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

//seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

app.UseMiddleware<ExceptionMiddleware>();

// CORS dalsza część policy, używa z nazwą ze stringa
app.UseCors(frontendCorsPolicy);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
