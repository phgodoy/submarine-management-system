using Sms.Domain.Entities;
using Sms.Domain.Enums;
using Sms.Domain.Validation;
using Xunit;

namespace Sms.Test.SubmarineSystemTest
{
    public class SubmarineSystemCrudTests
    {
        [Fact]
        public void Create_ValidSubmarineSystem_ShouldNotThrowException()
        {
            var exception = Record.Exception(() =>
                new SubmarineSystem(1, "Sonar", "Navigation", SystemStatusEnum.InOperation, DateTime.Now.AddDays(-10)));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Create_InvalidName_ShouldThrowException(string invalidName)
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new SubmarineSystem(1, invalidName, "Navigation", SystemStatusEnum.InOperation, DateTime.Now));

            Assert.Equal("Invalid: name is required", ex.Message);
        }

        [Fact]
        public void Create_ShortName_ShouldThrowException()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new SubmarineSystem(1, "AB", "Navigation", SystemStatusEnum.InOperation, DateTime.Now));

            Assert.Equal("Invalid: name is too short", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Create_InvalidType_ShouldThrowException(string invalidType)
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new SubmarineSystem(1, "Radar", invalidType, SystemStatusEnum.InOperation, DateTime.Now));

            Assert.Equal("Invalid: type is required", ex.Message);
        }

        [Fact]
        public void Create_InvalidSystemStatus_ShouldThrowException()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new SubmarineSystem(1, "Radar", "Sensor", (SystemStatusEnum)999, DateTime.Now));

            Assert.Equal("Invalid: operational status is not valid", ex.Message);
        }

        [Fact]
        public void Create_WithNegativeId_ShouldThrowException()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new SubmarineSystem(-1, 1, "Radar", "Sensor", SystemStatusEnum.InOperation, DateTime.Now));

            Assert.Equal("Invalid id value", ex.Message);
        }

        [Fact]
        public void Update_ShouldModifyProperties()
        {
            var system = new SubmarineSystem(1, "Radar", "Sensor", SystemStatusEnum.InOperation, DateTime.Now.AddDays(-5));

            system.Update(2, "Sonar", "Navigation", SystemStatusEnum.Committed, DateTime.Now);

            Assert.Equal(2, system.SubmarineId);
            Assert.Equal("Sonar", system.Name);
            Assert.Equal("Navigation", system.Type);
            Assert.Equal(SystemStatusEnum.Committed, system.SystemStatusId);
        }

        [Fact]
        public void UpdateOperationalSystem_ShouldChangeStatus()
        {
            var system = new SubmarineSystem(1, "Radar", "Sensor", SystemStatusEnum.InOperation, DateTime.Now);

            system.UpdateOperationalSystem(SystemStatusEnum.Disable);

            Assert.Equal(SystemStatusEnum.Disable, system.SystemStatusId);
        }
    }
}
