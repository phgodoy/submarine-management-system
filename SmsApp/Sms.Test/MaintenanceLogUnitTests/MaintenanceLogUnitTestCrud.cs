using Sms.Domain.Entities;
using Sms.Domain.Validation;
using Xunit;

namespace Sms.Test
{
    public class MaintenanceLogUnitTestCrud
    {
        private readonly DateTime fixedMaintenanceDate = new DateTime(2024, 01, 15); // Data fixa para testes

        [Fact(DisplayName = "Create MaintenanceLog with Valid Parameters")]
        public void CreateMaintenanceLog_WithValidParameters_ResultObjectValidState()
        {
            // Arrange
            int submarineSystemId = 1;
            string technicianName = "John Doe";
            string notes = "Routine maintenance check completed successfully.";

            // Act
            var maintenanceLog = new MaintenanceLog(submarineSystemId, fixedMaintenanceDate, technicianName, notes);

            // Assert
            Assert.NotNull(maintenanceLog);
            Assert.Equal(submarineSystemId, maintenanceLog.SubmarineSystemId);
            Assert.Equal(fixedMaintenanceDate, maintenanceLog.MaintenanceDate);
            Assert.Equal(technicianName, maintenanceLog.TechnicianName);
            Assert.Equal(notes, maintenanceLog.Notes);
        }

        [Fact(DisplayName = "Create MaintenanceLog with Future Maintenance Date")]
        public void CreateMaintenanceLog_WithFutureMaintenanceDate_ThrowsDomainException()
        {
            // Arrange
            int submarineSystemId = 1;
            DateTime futureMaintenanceDate = new DateTime(2030, 12, 25); // Data futura fixa
            string technicianName = "John Doe";
            string notes = "Routine maintenance check.";

            // Act
            Action action = () => new MaintenanceLog(submarineSystemId, futureMaintenanceDate, technicianName, notes);

            // Assert
            var exception = Assert.Throws<DomainExceptionValidation>(action);
            Assert.Equal("Maintenance date cannot be in the future.", exception.Message);
        }

        [Fact(DisplayName = "Update MaintenanceLog with Valid Parameters")]
        public void UpdateMaintenanceLog_WithValidParameters_ShouldUpdateProperties()
        {
            // Arrange
            var maintenanceLog = CreateBasicMaintenanceLog();
            int newSubmarineSystemId = 2;
            DateTime newMaintenanceDate = new DateTime(2023, 12, 10); // Nova data fixa
            string newTechnicianName = "Jane Doe";
            string newNotes = "Updated maintenance log with additional details.";

            // Act
            maintenanceLog.Update(newSubmarineSystemId, newMaintenanceDate, newTechnicianName, newNotes);

            // Assert
            Assert.Equal(newSubmarineSystemId, maintenanceLog.SubmarineSystemId);
            Assert.Equal(newMaintenanceDate, maintenanceLog.MaintenanceDate);
            Assert.Equal(newTechnicianName, maintenanceLog.TechnicianName);
            Assert.Equal(newNotes, maintenanceLog.Notes);
        }

        private MaintenanceLog CreateBasicMaintenanceLog()
        {
            return new MaintenanceLog(1, new DateTime(2024, 01, 15), "John Doe", "Routine maintenance check.");
        }
    }
}
