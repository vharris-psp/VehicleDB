using System;
using System.ComponentModel.DataAnnotations;

public class Trip
{
    [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime? ReturnDate { get; set; }
    public TimeSpan DepartureTime { get; set; }
    public TimeSpan ArrivalTime { get; set; }
    public TimeSpan? ReturnDepartureTime { get; set; }
    public TimeSpan? ReturnArrivalTime { get; set; }
    public string ReasonForTrip { get; set; }
    public string VehicleVIN { get; set; }
    public Vehicle Vehicle { get; set; }
    public ICollection<Person> Passengers { get; set; }
    public int DepartureAddressId { get; set; }
    public Address DepartureAddress { get; set; }
    public int ArrivalAddressId { get; set; }
    public Address ArrivalAddress { get; set; }
    public int DriverID { get; set; }
    public Person Driver { get; set; }


}
