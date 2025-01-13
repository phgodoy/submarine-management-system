using Sms.Domain.Validation;

namespace Sms.Domain.Entities
{
    public class Submarine : Entity
    {
        public string Name { get; private set; }
        public string Model { get; private set; }
        public DateTime CommissionedDate { get; private set; }
        public int Status { get; private set; }

        private Submarine() { }

        public Submarine(int id, string name, string model, DateTime commissionedDate, int status)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            ID = id;
            ValidateDomain(name, model, commissionedDate, status);
        }

        public Submarine(string name, string model, DateTime commissionedDate, int status)
        {
            ValidateDomain(name, model, commissionedDate, status);
        }

        public void Update(string name, string model, DateTime commissionedDate, int status)
        {
            ValidateDomain(name, model, commissionedDate, status);
        }

        private void ValidateDomain(string name, string model, DateTime commissionedDate, int status)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Invalid: Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid: Name is too short");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(model), "Invalid: Model is required");
            DomainExceptionValidation.When(commissionedDate > DateTime.Now, "Invalid: Commissioned date cannot be in the future");
            DomainExceptionValidation.When(status < 0, "Invalid: Status must be a non-negative integer");

            Name = name;
            Model = model;
            CommissionedDate = commissionedDate;
            Status = status;
        }
    }
}
