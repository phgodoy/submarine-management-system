using Sms.Domain.Validation;

namespace Sms.Domain.Entities
{
    public class SubmarineSystemSetting : Entity
    {
        public int SubmarineSystemId { get; private set; }
        public string SettingKey { get; private set; }
        public string SettingValue { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public SubmarineSystem SubmarineSystem { get; private set; }

        private SubmarineSystemSetting() { }

        public SubmarineSystemSetting(int submarineSystemId, string settingKey, string settingValue, DateTime updatedAt)
        {
            ValidateDomain(submarineSystemId, settingKey, settingValue);
            UpdatedAt = updatedAt;
        }

        private void ValidateDomain(int submarineSystemId, string settingKey, string settingValue)
        {
            DomainExceptionValidation.When(submarineSystemId <= 0, "Invalid submarine system ID.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(settingKey), "Setting key is required.");
            DomainExceptionValidation.When(settingKey.Length > 100, "Setting key cannot exceed 100 characters.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(settingValue), "Setting value is required.");
            DomainExceptionValidation.When(settingValue.Length > 100, "Setting value cannot exceed 100 characters.");

            SubmarineSystemId = submarineSystemId;
            SettingKey = settingKey;
            SettingValue = settingValue;
        }
    }
}
