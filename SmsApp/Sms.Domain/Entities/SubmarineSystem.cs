using Sms.Domain.Enums;
using Sms.Domain.Validation;

namespace Sms.Domain.Entities
{
    public class SubmarineSystem : Entity
    {
        public int SubmarineId { get; private set; }

        public Submarine Submarine { get; private set; }

        public string Name { get; private set; }

        public SystemStatusEnum SystemStatusId { get; private set; }

        public SystemStatus SystemStatus { get; private set; }

        public DateTime LastMaintenanceDate { get; private set; }

        public string Type { get; private set; }

        private SubmarineSystem() { }

        public SubmarineSystem(int submarineId, string name, string type, SystemStatusEnum systemStatus, DateTime lastMaintenanceDate)
        {
            ValidateDomain(name, type, systemStatus);
            SubmarineId = submarineId;
            LastMaintenanceDate = lastMaintenanceDate;
            Type = type;
        }

        public SubmarineSystem(int id, int submarineId, string name, string type, SystemStatusEnum systemStatus, DateTime lastMaintenanceDate)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            ID = id;
            ValidateDomain(name, type, systemStatus);
            SubmarineId = submarineId;
            LastMaintenanceDate = lastMaintenanceDate;
            Type = type;
        }

        public void Update(int submarineId, string name, string type, SystemStatusEnum systemStatus, DateTime lastMaintenanceDate)
        {
            ValidateDomain(name, type, systemStatus);
            SubmarineId = submarineId;
            LastMaintenanceDate = lastMaintenanceDate;
            Type = type;
        }

        private void ValidateDomain(string name, string type, SystemStatusEnum systemStatus)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Invalid: name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid: name is too short");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(type), "Invalid: type is required");
            DomainExceptionValidation.When(!Enum.IsDefined(typeof(SystemStatusEnum), systemStatus), "Invalid: operational status is not valid");

            Name = name;
            SystemStatusId = systemStatus;
        }
    }
}
