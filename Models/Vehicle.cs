using System.ComponentModel.DataAnnotations;

public class Vehicle
{
    [Key]
    [Required(ErrorMessage = "VIN is required.")]
    [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN must be exactly 17 Characters")]
    public string VIN { get; set; }
    public int StartingMileage { get; set; }
    [Required(ErrorMessage = "Year is required.")]
    public int Year { get; set; }
    [Required(ErrorMessage = "Make is required.")]
    public string Make { get; set; }
    [Required(ErrorMessage = "Model is required.")]
    public string Model { get; set; }
    public int EndingMileage { get; set; }
    public int FuelLevel { get; set; }
    public int StartingCondition { get; set; }
    public int EndingCondition { get; set; }
    public string ReasonForTrip { get; set; }
    public ICollection<Trip> Trips { get; set; }
    public ICollection<Person> Persons { get; set; }
    
}
