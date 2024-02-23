using System.ComponentModel.DataAnnotations;

public class Vehicle
{
    [Key]
    [Required(ErrorMessage = "VIN is required.")]
    [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN must be exactly 17 Characters")]
    public string VIN { get; set; }
    
    [Required(ErrorMessage = "Year is required.")]
    public int Year { get; set; }
    [Required(ErrorMessage = "Make is required.")]
    public string Make { get; set; }
    [Required(ErrorMessage = "Model is required.")]
    public string Model { get; set; }
    [Required(ErrorMessage = "Mileage is required.")]
    public int CurrentMileage { get; set; }
    [Required(ErrorMessage = "Fuel level is required.")]
    public FuelLevel CurrentFuelLevel { get; set; }
    [Required(ErrorMessage = "Condition is required.")]
    public Condition CurrentCondition { get; set; }
    public ICollection<Trip> Trips { get; set; }
    public enum FuelLevel
    {
    Empty,
    Quarter,
    Half,
    ThreeQuarter,
    Full
    }

    public enum Condition
    {
    Poor,
    Fair,
    Good,
    Excellent
    }
}
