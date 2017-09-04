  using Microsoft.EntityFrameworkCore;

namespace CarMaintenanceAPI.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
    }
}