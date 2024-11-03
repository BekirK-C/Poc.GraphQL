using Bogus;

namespace GraphQL.API.Schema.Queries;

public class Query
{
    private readonly Faker<ReservationType> _fakeReservation;
    private readonly Faker<ProfileType> _fakeProfile;
    
    public Query()
    {
        _fakeReservation = new Faker<ReservationType>()
            .RuleFor(r => r.Id, f => f.Random.Guid())
            .RuleFor(r => r.ArrivalDate, f => f.Date.Past())
            .RuleFor(r => r.DepartureDate, f => f.Date.Future())
            .RuleFor(r => r.NumberOfGuests, f => f.Random.Number(1, 5))
            .RuleFor(r => r.Status, f => f.PickRandomParam("Confirmed", "Pending", "Cancelled"))
            .RuleFor(r => r.Profile, f => _fakeProfile?
                .Generate(2));

        _fakeProfile = new Faker<ProfileType>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.Name, f => f.Name.FullName())
            .RuleFor(p => p.Email, f => f.Internet.Email())
            .RuleFor(p => p.Phone, f => f.Phone.PhoneNumber());
    }
    

    public string Hello() => "Hello World!";
    
    [UsePaging(DefaultPageSize = 10)]
    public List<ReservationType> Reservations() => _fakeReservation.Generate(21);

    public ReservationType GetReservation(Guid id)
    {
        var reservation = _fakeReservation.Generate();
        reservation.Id = id;
        return reservation;
    }
    public List<ProfileType> Profiles() => _fakeProfile.Generate(3);
    
    public ProfileType GetProfile(Guid id)
    {
        var profile = _fakeProfile.Generate();
        profile.Id = id;
        return profile;
    }
}