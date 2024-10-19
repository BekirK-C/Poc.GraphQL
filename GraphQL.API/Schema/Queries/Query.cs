using Bogus;

namespace GraphQL.API.Schema.Queries;

public class Query
{
    public string Hello() => "Hello World!";

    private readonly List<ReservationType> _fakeReservation = new Faker<ReservationType>()
        .StrictMode(true)
        .RuleFor(r => r.Id, f => f.Random.Guid())
        .RuleFor(r => r.ArrivalDate, f => f.Date.Past())
        .RuleFor(r => r.DepartureDate, f => f.Date.Future())
        .RuleFor(r => r.NumberOfGuests, f => f.Random.Number(1, 5))
        .RuleFor(r => r.Status, f => f.PickRandomParam("Confirmed", "Pending", "Cancelled"))
        .RuleFor(r => r.Profile, f =>
        [
            new ProfileType
            {
                Id = f.Random.Guid(),
                Name = f.Name.FullName(),
                Email = f.Internet.Email(),
                Phone = f.Phone.PhoneNumber()
            }
        ]).Generate(5);

    public List<ReservationType> Reservations() => _fakeReservation;
}