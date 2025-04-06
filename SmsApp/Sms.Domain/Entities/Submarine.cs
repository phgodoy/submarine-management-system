using Sms.Domain.Enums;
using Sms.Domain.Validation;

namespace Sms.Domain.Entities
{
    public class Submarine : Entity
    {
        public string Name { get; private set; }
        public string Model { get; private set; }
        public DateTime CreationDate { get; private set; }

        public SubmarineStatus SubmarineStatus { get; private set; }

        public SubmarineStatusEnum SubmarineStatusId { get; private set; }

        public IEnumerable<SubmarineSystem> SubmarineSystems { get; private set; }

        private Submarine() { }

        public Submarine(int id, string name, string model, DateTime creationDate, SubmarineStatusEnum submarineStatusId)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            ID = id;
            ValidateDomain(name, model, creationDate);
            SubmarineStatusId = submarineStatusId;
        }

        public Submarine(string name, string model, DateTime creationDate, SubmarineStatusEnum submarineStatusId)
        {
            ValidateDomain(name, model, creationDate);

            Name = name;
            Model = model;
            CreationDate = creationDate;
            SubmarineStatusId = submarineStatusId;
        }

        public void Update(string name, string model, DateTime creationDate, SubmarineStatusEnum submarineStatusId)
        {
            ValidateDomain(name, model, creationDate);
            Name = name;
            Model = model;
            CreationDate = creationDate;
            SubmarineStatusId = submarineStatusId;
        }

        public void UpdateSubmarineStatus(SubmarineStatusEnum submarineStatus)
        {
            SubmarineStatusId = submarineStatus;
        }

        private void ValidateDomain(string name, string model, DateTime creationDate)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Invalid: Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid: Name is too short");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(model), "Invalid: Model is required");
            DomainExceptionValidation.When(creationDate > DateTime.Now, "Invalid: creation date cannot be in the future");
        }
    }
}