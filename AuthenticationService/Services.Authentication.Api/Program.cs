using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Authentication.Api.Services;
using Services.Authentication.Data;
using Services.Authentication.Model.Entities;
using Services.Shared.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthenticationTokenServerHelper(builder.Configuration);
builder.Services.AddAuthenticationDb(builder.Configuration); 
builder.Services.AddIdentity<AppUser, AppRole>(setup =>
{
    setup.Password.RequireLowercase = false;
    setup.Password.RequiredLength = 6;
    setup.Password.RequireNonAlphanumeric = false;
    setup.Password.RequiredUniqueChars = 0;
}).AddEntityFrameworkStores<AuthenticationDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IdentityService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using var scope = app.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<AuthenticationDbContext>();
    //dataContext.Database.Migrate();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
