using System.Collections.Generic;

namespace CarMaintenanceAPI.Models
{
    public class Owner 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}