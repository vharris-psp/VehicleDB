using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class RentalLocation
{
    [Key]
    public int StoreID { get; set; }

    [Required]
    public Address StoreAddress { get; set; }

    // Navigation property for the relationship with Vehicle
    public ICollection<Vehicle> VehiclesInInventory { get; set; } = new List<Vehicle>();

    // Additional properties and methods
}
