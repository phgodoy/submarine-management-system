using Sms.Domain.Validation;

namespace Sms.Domain.Entities
{
    public class SubmarineSystem : Entity
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string OperationalStatus { get; private set; }
        public DateTime LastMaintenanceDate { get; private set; }

        private SubmarineSystem() { }

        public SubmarineSystem( string name, string type, string operationalStatus, DateTime lastMaintenanceDate)
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

        private void ValidateDomain(string name, string type, string operationalStatus)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid: name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid: name is too short");
            DomainExceptionValidation.When(string.IsNullOrEmpty(type), "Invalid: type is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(operationalStatus), "Invalid: operational status is required");

            Name = name;
            Type = type;
            OperationalStatus = operationalStatus;
        }
    }
}
