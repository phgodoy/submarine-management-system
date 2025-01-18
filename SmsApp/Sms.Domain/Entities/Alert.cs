using Sms.Domain.Validation;

namespace Sms.Domain.Entities
{
    public class Alert
    {
        public int Id { get; private set; }
        public int SubmarineSystemId { get; private set; }
        public string AlertType { get; private set; }
        public string Message { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ResolvedAt { get; private set; }

        public SubmarineSystem SubmarineSystem { get; private set; }

        private Alert() { }

        public Alert(int submarineSystemId, string alertType, string message, DateTime createdAt)
        {
            ValidateDomain(submarineSystemId, alertType, message, createdAt);
        }

        public void ResolveAlert(DateTime resolvedAt)
        {
            DomainExceptionValidation.When(resolvedAt < CreatedAt, "Resolved date cannot be before the creation date.");
            ResolvedAt = resolvedAt;
        }

        private void ValidateDomain(int submarineSystemId, string alertType, string message, DateTime createdAt)
        {
            DomainExceptionValidation.When(submarineSystemId <= 0, "Invalid submarine system ID.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(alertType), "Alert type is required.");
            DomainExceptionValidation.When(alertType.Length > 50, "Alert type must not exceed 50 characters.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(message), "Message is required.");
            DomainExceptionValidation.When(message.Length > 500, "Message must not exceed 500 characters.");
            DomainExceptionValidation.When(createdAt > DateTime.Now, "Creation date cannot be in the future.");

            SubmarineSystemId = submarineSystemId;
            AlertType = alertType;
            Message = message;
            CreatedAt = createdAt;
        }
    }
}
