using System;

namespace CarMaintenanceAPI.Models
{
    public class Maintenance 
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int TypeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Description { get; set; }

        public Car Car { get; set; }
        public MaintenanceType Type { get; set; }
    }
}