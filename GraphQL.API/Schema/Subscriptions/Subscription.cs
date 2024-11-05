using GraphQL.API.Schema.Queries;

namespace GraphQL.API.Schema.Subscriptions;

public class Subscription
{
    [Subscribe]
    public ReservationType OnReservationCreated([EventMessage] ReservationType reservation)
    {
        return reservation;
    }
}