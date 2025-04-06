using Sms.Domain.Entities;
using Sms.Domain.Enums;
using Sms.Domain.Validation;
using System;
using Xunit;

namespace Sms.Test.SubmarineTest
{
    public class SubmarineCrudTests
    {
        [Fact]
        public void Create_ValidSubmarine_ShouldNotThrowException()
        {
            var exception = Record.Exception(() =>
                new Submarine("Nautilus", "Model-X", DateTime.Now.AddYears(-5), SubmarineStatusEnum.InOperation));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Create_InvalidName_ShouldThrowException(string invalidName)
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new Sms.Domain.Entities.Submarine(invalidName, "Model-X", DateTime.Now, SubmarineStatusEnum.InOperation));

            Assert.Equal("Invalid: Name is required", ex.Message);
        }

        [Fact]
        public void Create_ShortName_ShouldThrowException()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new Sms.Domain.Entities.Submarine("AB", "Model-X", DateTime.Now, SubmarineStatusEnum.InOperation));

            Assert.Equal("Invalid: Name is too short", ex.Message);
        }

        [Fact]
        public void Create_InvalidModel_ShouldThrowException()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new Sms.Domain.Entities.Submarine("Nautilus", "", DateTime.Now, SubmarineStatusEnum.InOperation));

            Assert.Equal("Invalid: Model is required", ex.Message);
        }

        [Fact]
        public void Create_FutureCreationDate_ShouldThrowException()
        {
            var futureDate = DateTime.Now.AddDays(1);

            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new Sms.Domain.Entities.Submarine("Nautilus", "Model-X", futureDate, SubmarineStatusEnum.InOperation));

            Assert.Equal("Invalid: creation date cannot be in the future", ex.Message);
        }

        [Fact]
        public void Update_ShouldModifyProperties()
        {
            var submarine = new Sms.Domain.Entities.Submarine("OldName", "OldModel", DateTime.Now.AddYears(-3), SubmarineStatusEnum.Deactivated);

            submarine.Update("NewName", "NewModel", DateTime.Now.AddYears(-1), SubmarineStatusEnum.UnderMaintenance);

            Assert.Equal("NewName", submarine.Name);
            Assert.Equal("NewModel", submarine.Model);
            Assert.Equal(SubmarineStatusEnum.UnderMaintenance, submarine.SubmarineStatusId);
        }

        [Fact]
        public void UpdateSubmarineStatus_ShouldChangeStatus()
        {
            var submarine = new Sms.Domain.Entities.Submarine("Test", "Model-A", DateTime.Now.AddYears(-2), SubmarineStatusEnum.Deactivated);

            submarine.UpdateSubmarineStatus(SubmarineStatusEnum.InOperation);

            Assert.Equal(SubmarineStatusEnum.InOperation, submarine.SubmarineStatusId);
        }

        [Fact]
        public void Create_WithNegativeId_ShouldThrowException()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new Sms.Domain.Entities.Submarine(-1, "ValidName", "Model", DateTime.Now.AddYears(-2), SubmarineStatusEnum.InOperation));

            Assert.Equal("Invalid id value", ex.Message);
        }
    }
}
