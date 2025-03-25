using Sms.Domain.Enums;
using Sms.Domain.Validation;

namespace Sms.Domain.Entities
{
    public class SystemStatus
    {
        public SystemStatusEnum ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        private SystemStatus() { }

        public SystemStatus(SystemStatusEnum id, string name, string description)
        {
            ValidateDomain(id, name, description);
            ID = id;
            Name = name;
            Description = description;
        }

        private void ValidateDomain(SystemStatusEnum id, string name, string description)
        {
            DomainExceptionValidation.When(!Enum.IsDefined(typeof(SystemStatusEnum), id), "Invalid id value");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Invalid: Name is required");
            DomainExceptionValidation.When(name.Length > 100, "Invalid: Name is too long (max 100 characters)");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description), "Invalid: Description is required");
            DomainExceptionValidation.When(description.Length > 255, "Invalid: Description is too long (max 255 characters)");
        }
    }
}
