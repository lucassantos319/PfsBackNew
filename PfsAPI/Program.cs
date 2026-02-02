using Microsoft.EntityFrameworkCore;
using PfsApplications.Applications;
using PfsDomain.Interfaces.Applications;
using PfsDomain.Interfaces.Repositories;
using PfsInfrastructure.Configurations;
using PfsInfrastructure.Repositories;
using PfsInfrastructure.Repositories.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureMapping();
builder.Services.AddScoped<IUsersApp, UsersApp>();
builder.Services.AddScoped<IPainelUserApp, PainelUserApp>();
builder.Services.AddScoped<IUsersRepo, UsersRepo>();
builder.Services.AddScoped<IPainelUserRepo, PainelUserRepo>();

builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Host=localhost;Port=5432;Username=postgres;Database=pfs;Password=admin")
    )
);

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

app.Run();
