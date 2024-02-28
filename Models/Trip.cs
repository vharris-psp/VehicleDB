using System;
using System.ComponentModel.DataAnnotations;

public class Trip
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Date is required.")]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "Return date is required.")]
    public DateTime? ReturnDate { get; set; }
    [Required(ErrorMessage = "Departure time is required.")]
    public TimeSpan DepartureTime { get; set; }
    [Required(ErrorMessage = "Arrival time is required.")]
    public TimeSpan ArrivalTime { get; set; }
    
    public TimeSpan? ReturnDepartureTime { get; set; }
    public TimeSpan? ReturnArrivalTime { get; set; }
    public string ReasonForTrip { get; set; } = "";
    public Vehicle Vehicle { get; set; }
    public string VehicleVIN { get; set; }
    public ICollection<Person> Passengers { get; set; }
    public RentalLocation PickupLocation { get; set; }
    public RentalLocation DropOffLocation { get; set; }
    public int DriverID { get; set; }
    public Person Driver { get; set; }


}
