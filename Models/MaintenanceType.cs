using System.Collections.Generic;

namespace CarMaintenanceAPI.Models
{
    public class MaintenanceType 
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Maintenance> Maintenances { get; set; }
    }
}