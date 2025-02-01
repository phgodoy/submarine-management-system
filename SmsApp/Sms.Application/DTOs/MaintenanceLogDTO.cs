namespace Sms.Application.DTOs
{
    public class MaintenanceLogDTO
    {
        public int Id { get; set; }
        public int SubmarineSystemId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string TechnicianName { get; set; }
        public string Notes { get; set; }

        // Submarine System can be included as well if needed
        public SubmarineSystemDTO SubmarineSystem { get; set; }

        public MaintenanceLogDTO() { }

        public MaintenanceLogDTO(int id, int submarineSystemId, DateTime maintenanceDate, string technicianName, string notes)
        {
            Id = id;
            SubmarineSystemId = submarineSystemId;
            MaintenanceDate = maintenanceDate;
            TechnicianName = technicianName;
            Notes = notes;
        }
    }
}
