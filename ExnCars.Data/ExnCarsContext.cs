using ExnCars.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExnCars.Data
{
  public class ExnCarsContext : DbContext
  {
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleDetail> VehicleDetails { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserVehicles> UserVehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=ExnCars;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //modelBuilder.Entity<VehicleDetail>().HasKey(vd => vd.VehicleId);
      modelBuilder.Entity<UserVehicles>().HasKey(uv => new { uv.UserId, uv.VehicleId });
    }
  }
}
