using AspNetCoreGraphQLClient.Services;

using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGraphQLClient>(s => 
    new GraphQLHttpClient(new GraphQLHttpClientOptions()
        {
            EndPoint = new Uri(builder.Configuration["GraphQLServerUri"])            
        },
        new NewtonsoftJsonSerializer()));

builder.Services.AddScoped<IPlayerService, PlayerService>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
