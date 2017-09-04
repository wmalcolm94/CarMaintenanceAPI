using System.Collections.Generic;

namespace CarMaintenanceAPI.Models
{
    public class VehicleType 
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}