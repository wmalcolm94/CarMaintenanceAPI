namespace CarMaintenanceAPI.Models
{
    public class Car 
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }

        public Owner Owner { get; set; }
        public VehicleType Type { get; set; }
    }
}