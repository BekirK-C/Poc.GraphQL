namespace GraphQL.API.Schema.Queries;

public class ReservationType
{
    public Guid Id { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public int NumberOfGuests { get; set; }
    public string Status { get; set; }
    public List<ProfileType> Profile { get; set; }
}