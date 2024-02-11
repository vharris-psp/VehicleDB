using System.ComponentModel.DataAnnotations;

public class Address
{
    [Key]
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public ICollection<Trip> DepartureTrips { get; set; }
    public ICollection<Trip> ArrivalTrips { get; set; }
    
}
