using GraphQL.API.Schema.Queries;
using GraphQL.API.Schema.Subscriptions;
using HotChocolate.Subscriptions;

namespace GraphQL.API.Schema.Mutations;

public class ReservationMutation
{
    private static readonly List<Guid> Reservations = [];

    public async Task<List<Guid>> CreateReservation(CreateReservationInput input, ITopicEventSender eventSender)
    {
        var reservation = new ReservationType
        {
            Id = Guid.NewGuid(),
            ArrivalDate = input.ArrivalDate,
            DepartureDate = input.DepartureDate,
            NumberOfGuests = input.NumberOfGuests,
            Status = input.Status,
            Profile = input.ProfileIds.Select(id => new ProfileType { Id = id }).ToList()
        };
        
        Reservations.Add(reservation.Id);
        
        await eventSender.SendAsync(nameof(Subscription.OnReservationCreated), reservation);
        
        return Reservations;
    }
    
    public List<Guid> DeleteReservation(Guid id)
    {
        Reservations.Remove(id);
        
        return Reservations;
    }
    
    public List<Guid> UpdateReservation(Guid id, CreateReservationInput input)
    {
        var reservation = new ReservationType
        {
            Id = id,
            ArrivalDate = input.ArrivalDate,
            DepartureDate = input.DepartureDate,
            NumberOfGuests = input.NumberOfGuests,
            Status = input.Status,
            Profile = input.ProfileIds.Select(guid => new ProfileType { Id = guid }).ToList()
        };
        
        Reservations.Remove(id);
        Reservations.Add(reservation.Id);
        
        return Reservations;
    }
}