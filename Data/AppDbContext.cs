using Microsoft.EntityFrameworkCore;
using VehicleDB.Models;
namespace VehicleDB
{
public class VehicleDbContext : DbContext
{
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Person> Persons { get; set; } // Changed from Person to Persons
    public DbSet<Issue> Issues { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Store> Stores { get; set; }
    public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Trip>()
            .HasOne(t => t.Vehicle)
            .WithMany(v => v.Trips)
            .HasForeignKey(t => t.VehicleVIN);
        modelBuilder.Entity<Trip>()
            .HasMany(t => t.Passengers)
            .WithMany(v => v.PassengerTrips)
            .UsingEntity(j => j.ToTable("TripPassenger"));
        modelBuilder.Entity<Trip>()
                .HasOne(t => t.Driver)          // Assuming Driver is the navigation property in Trip referring to a Person entity
                .WithMany(p => p.DrivenTrips)         // Assuming Trips is the navigation property in Person referring to a collection of Trip entities
                .HasForeignKey(t => t.Id); 
        modelBuilder.Entity<Store>()
                .OwnsOne(s => s.Hours); 
        base.OnModelCreating(modelBuilder);
    }
}
}