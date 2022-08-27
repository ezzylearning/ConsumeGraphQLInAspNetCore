using AspNetCoreGraphQLServer.Data;
using AspNetCoreGraphQLServer.Mutations;
using AspNetCoreGraphQLServer.Queries;
using AspNetCoreGraphQLServer.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SportsDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPlayerService, PlayerService>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType(q => q.Name("Query"))
    .AddType<PlayerQueryResolver>()
    .AddMutationType(m => m.Name("Mutation"))
    .AddType<PlayerMutationResolver>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapGraphQL();

app.Run();
