using GraphQL.API.Schema.Mutations;
using GraphQL.API.Schema.Queries;
using GraphQL.API.Schema.Subscriptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<ReservationMutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions()
    .AddFiltering()
    .AddSorting()
    .AddProjections();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWebSockets();
app.UseHttpsRedirection();
app.MapGraphQL();

app.Run();