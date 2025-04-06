using System;
using System.ComponentModel.DataAnnotations;
using Sms.Domain.Enums;

namespace Sms.Application.Dtos
{
    public class SubmarineSystemDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "SubmarineId is required.")]
        public int SubmarineId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        [MaxLength(255, ErrorMessage = "Name cannot exceed 255 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "System status is required.")]
        public SystemStatusEnum SystemStatusId { get; set; }

        [Required(ErrorMessage = "Last maintenance date is required.")]
        public DateTime LastMaintenanceDate { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [MinLength(3, ErrorMessage = "Type must be at least 3 characters long.")]
        [MaxLength(255, ErrorMessage = "Type cannot exceed 255 characters.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "The System Status is required.")]
        public SystemStatusDto SystemStatusDto { get; set; }
    }
}
