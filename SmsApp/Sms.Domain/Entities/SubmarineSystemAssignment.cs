using Sms.Domain.Validation;

namespace Sms.Domain.Entities
{
    public class SubmarineSystemAssignment : Entity
    {
        public int SubmarineId { get; private set; }
        public int SubmarineSystemId { get; private set; }
        public bool Status { get; private set; }

        public Submarine Submarine { get; private set; }
        public SubmarineSystem SubmarineSystem { get; private set; }

        private SubmarineSystemAssignment() { }

        public SubmarineSystemAssignment(int submarineId, int submarineSystemId, bool status)
        {
            ValidateDomain(submarineId, submarineSystemId);
            Status = status;
        }

        public SubmarineSystemAssignment(int id, int submarineId, int submarineSystemId, bool status)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            ValidateDomain(submarineId, submarineSystemId);
            ID = id;
            Status = status;
        }

        public void Update(int submarineId, int submarineSystemId, bool status)
        {
            ValidateDomain(submarineId, submarineSystemId);
            SubmarineId = submarineId;
            SubmarineSystemId = submarineSystemId;
            Status = status;
        }

        private void ValidateDomain(int submarineId, int submarineSystemId)
        {
            DomainExceptionValidation.When(submarineId <= 0, "Invalid SubmarineId value. Must be greater than zero.");
            DomainExceptionValidation.When(submarineSystemId <= 0, "Invalid SubmarineSystemId value. Must be greater than zero.");
        }

        public void UpdateStatus(bool status)
        {
            Status = status;
        }
    }
}
