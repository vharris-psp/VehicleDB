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
    public DateTime DOB { get; set; }
    public ICollection<Trip> DrivenTrips { get; set; }
    public ICollection<Trip> PassengerTrips { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }


}
