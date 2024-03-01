using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

public class Person
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; }
    public string FullName { get { return $"{FirstName} {LastName}";}}
    [Required(ErrorMessage = "Birth date is required.")]
    [DataType(DataType.Date)]
    public DateOnly DOB { get; set; }  

    [Required(ErrorMessage = "Address Required")]
    public Address Address { get; set; }
    // Navigation properties
    public ICollection<Trip> DrivenTrips { get; set; } = new List<Trip>(); // Trips where this person is the driver
    public ICollection<Trip> PassengerTrips { get; set; } = new List<Trip>(); // Trips where this person is a passenger
    
}
