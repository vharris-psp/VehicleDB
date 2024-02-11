using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

public class Person
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get { return $"{FirstName} {LastName}";}}
    public DateTime DOB { get; set; }
    public ICollection<Trip> DrivenTrips { get; set; }
    public ICollection<Trip> PassengerTrips { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }


}
