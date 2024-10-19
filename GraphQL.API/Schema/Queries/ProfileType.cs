namespace GraphQL.API.Schema.Queries;

public class ProfileType
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public ReservationType Reservation { get; set; }
}