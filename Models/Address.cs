using System.ComponentModel.DataAnnotations;

public class Address
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Street address is required")]
    public string Street { get; set; }
    [Required(ErrorMessage = "City is required.")]
    public string City { get; set; }
    [Required(ErrorMessage = "State is required.")]                                 
    public string State { get; set; }
    [Required(ErrorMessage = "Zip code is required.")]
    public string Zip { get; set; }
    public ICollection<Trip> DepartureTrips { get; set; }
    public ICollection<Trip> ArrivalTrips { get; set; }
    
}
