using Sms.Domain.Validation;

namespace Sms.Domain.Entities
{
    public class MaintenanceLog : Entity
    {
        public int SubmarineSystemId { get; private set; }
        public DateTime MaintenanceDate { get; private set; }
        public string TechnicianName { get; private set; }
        public string Notes { get; private set; }

        public SubmarineSystem SubmarineSystem { get; private set; }
    
        private MaintenanceLog() { }

        public MaintenanceLog(int submarineSystemId, DateTime maintenanceDate, string technicianName, string notes)
        {
            ValidateDomain(submarineSystemId, maintenanceDate, technicianName, notes);
        }

        public MaintenanceLog(int id, int submarineSystemId, DateTime maintenanceDate, string technicianName, string notes)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value.");
            ID = id;
            ValidateDomain(submarineSystemId, maintenanceDate, technicianName, notes);
        }

        public void Update(int submarineSystemId, DateTime maintenanceDate, string technicianName, string notes)
        {
            ValidateDomain(submarineSystemId, maintenanceDate, technicianName, notes);
        }

        private void ValidateDomain(int submarineSystemId, DateTime maintenanceDate, string technicianName, string notes)
        {
            DomainExceptionValidation.When(submarineSystemId <= 0, $"Invalid submarine system ID: {submarineSystemId}.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(technicianName), "Technician name is required.");
            DomainExceptionValidation.When(technicianName.Length < 3, "Technician name must be at least 3 characters.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(notes), "Notes are required.");
            DomainExceptionValidation.When(notes.Length < 10, "Notes must be at least 10 characters.");
            DomainExceptionValidation.When(maintenanceDate > DateTime.Now, "Maintenance date cannot be in the future.");

            SubmarineSystemId = submarineSystemId;
            MaintenanceDate = maintenanceDate;
            TechnicianName = technicianName;
            Notes = notes;
        }
    }
}
