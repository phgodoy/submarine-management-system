using Sms.Domain.Validation;

namespace Sms.Domain.Entities
{
    public class SubmarineSystem : Entity
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string OperationalStatus { get; private set; }
        public DateTime LastMaintenanceDate { get; private set; }

        public IEnumerable<SubmarineSystemAssignment> SubmarineSystemAssignments { get; set; }

        public IEnumerable<Alert> Alerts { get; private set; } = new List<Alert>();

        private SubmarineSystem() { }

        public SubmarineSystem(string name, string type, string operationalStatus, DateTime lastMaintenanceDate)
        {
            ValidateDomain(name, type, operationalStatus);
            LastMaintenanceDate = lastMaintenanceDate;
        }

        public SubmarineSystem(int id, string name, string type, string operationalStatus, DateTime lastMaintenanceDate)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            ID = id;
            ValidateDomain(name, type, operationalStatus);
            LastMaintenanceDate = lastMaintenanceDate;
        }

        public void Update(string name, string type, string operationalStatus, DateTime lastMaintenanceDate)
        {
            ValidateDomain(name, type, operationalStatus);
            LastMaintenanceDate = lastMaintenanceDate;
        }

        public void UpdateOperationalStatus(string operationalStatus)
        {
            ValidateOperationalStatus(operationalStatus);
            OperationalStatus = operationalStatus.ToLower();
        }

        private void ValidateDomain(string name, string type, string operationalStatus)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Invalid: name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid: name is too short");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(type), "Invalid: type is required");
            ValidateOperationalStatus(operationalStatus);

            Name = name;
            Type = type;
            OperationalStatus = operationalStatus;
        }

        private void ValidateOperationalStatus(string operationalStatus)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(operationalStatus), "Invalid: operational status is required");
            // Add further validation if needed (e.g., allowed values for operational status)
        }
    }
}
