namespace GraphQL.API.Schema.Mutations;

public class CreateReservationInput
{
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public int NumberOfGuests { get; set; }
    public string Status { get; set; }
    public List<Guid> ProfileIds { get; set; }
}