using GreenPipes;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Services.Email.Data;
using Services.Email.EventBus.Consumers;
using Services.Email.Repositories;
using Services.Email.Services;
using Services.Email.Services.Events;
using Services.Movie.Client.Base;
using Services.Shared.Authentication.Client;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEmailDb(builder.Configuration);
builder.Services.AddEmailDataRepositories();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<EmailEvents>();
builder.Services.AddMovieApiClient(op =>
{
    op.BaseUrl = ""; // for apigateway
    // TODO not harcoded and change
    op.ApiPath = "http://movie-service-db:3520/";
});
builder.Services.AddAuthenticationTokenClientHelper(builder.Configuration);


#region EventBus

builder.Services.AddMassTransit(c =>
{
    c.AddConsumersFromNamespaceContaining<EmailRequestEventConsumer>();
    c.SetKebabCaseEndpointNameFormatter();
    c.UsingRabbitMq((busContext, conf) =>
    {
        conf.Host(builder.Configuration.GetConnectionString("RabbitMQ"));
        conf.ConfigureEndpoints(busContext);
        conf.UseRetry(r => r.Interval(5, TimeSpan.FromSeconds(2)));
    });
});

builder.Services.AddMassTransitHostedService();

#endregion
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using var scope = app.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<EmailDbContext>();
    dataContext.Database.Migrate();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
