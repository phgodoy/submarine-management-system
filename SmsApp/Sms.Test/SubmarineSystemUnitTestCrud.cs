using Sms.Domain.Entities;
using Sms.Domain.Validation;
using Xunit;

namespace Sms.Test
{
    public class SubmarineSystemUnitTestCrud
    {
        [Fact(DisplayName = "Create SubmarineSystem with Valid Parameters")]
        public void CreateSubmarineSystem_WithValidParameters_ResultObjectValidState()
        {
            // Arrange
            string name = "Nautilus";
            string type = "Nuclear";
            string operationalStatus = "active";
            DateTime lastMaintenanceDate = DateTime.Now;

            // Act
            var submarineSystem = new SubmarineSystem(name, type, operationalStatus, lastMaintenanceDate);

            // Assert
            Assert.NotNull(submarineSystem);
            Assert.Equal(name, submarineSystem.Name);
            Assert.Equal(type, submarineSystem.Type);
            Assert.Equal(operationalStatus, submarineSystem.OperationalStatus);
            Assert.Equal(lastMaintenanceDate, submarineSystem.LastMaintenanceDate);
        }

        [Fact(DisplayName = "Create SubmarineSystem with Invalid Name")]
        public void CreateSubmarineSystem_WithInvalidName_ThrowsDomainException()
        {
            // Arrange
            string invalidName = "";
            string type = "Nuclear";
            string operationalStatus = "active";
            DateTime lastMaintenanceDate = DateTime.Now;

            // Act
            Action action = () => new SubmarineSystem(invalidName, type, operationalStatus, lastMaintenanceDate);

            // Assert
            var exception = Assert.Throws<DomainExceptionValidation>(action);
            Assert.Equal("Invalid: name is required", exception.Message);
        }

        [Fact(DisplayName = "Update SubmarineSystem with Valid Parameters")]
        public void UpdateSubmarineSystem_WithValidParameters_ShouldUpdateProperties()
        {
            // Arrange
            var submarineSystem = CreateBasicSubmarineSystem();
            string newName = "Nautilus-2";
            string newType = "Diesel";
            string newOperationalStatus = "inactive";
            DateTime newLastMaintenanceDate = DateTime.Now.AddDays(-10);

            // Act
            submarineSystem.Update(newName, newType, newOperationalStatus, newLastMaintenanceDate);

            // Assert
            Assert.Equal(newName, submarineSystem.Name);
            Assert.Equal(newType, submarineSystem.Type);
            Assert.Equal(newOperationalStatus, submarineSystem.OperationalStatus);
            Assert.Equal(newLastMaintenanceDate, submarineSystem.LastMaintenanceDate);
        }

        [Fact(DisplayName = "Update SubmarineSystem with Invalid Operational Status")]
        public void UpdateSubmarineSystem_WithInvalidOperationalStatus_ThrowsDomainException()
        {
            // Arrange
            var submarineSystem = CreateBasicSubmarineSystem();
            string invalidOperationalStatus = ""; // Empty status

            // Act
            Action action = () => submarineSystem.UpdateOperationalStatus(invalidOperationalStatus);

            // Assert
            var exception = Assert.Throws<DomainExceptionValidation>(action);
            Assert.Equal("Invalid: operational status is required", exception.Message);
        }

        [Fact(DisplayName = "Create SubmarineSystem with Invalid ID")]
        public void CreateSubmarineSystem_WithInvalidID_ThrowsDomainException()
        {
            // Arrange
            int invalidId = -1; // Negative ID
            string name = "Nautilus";
            string type = "Nuclear";
            string operationalStatus = "active";
            DateTime lastMaintenanceDate = DateTime.Now;

            // Act
            Action action = () => new SubmarineSystem(invalidId, name, type, operationalStatus, lastMaintenanceDate);

            // Assert
            var exception = Assert.Throws<DomainExceptionValidation>(action);
            Assert.Equal("Invalid id value", exception.Message);
        }

        private SubmarineSystem CreateBasicSubmarineSystem()
        {
            return new SubmarineSystem("Nautilus", "Nuclear", "active", DateTime.Now);
        }
    }
}
