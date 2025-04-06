using System.ComponentModel.DataAnnotations;
using Sms.Domain.Enums;

namespace Sms.Application.Dtos
{
    public class SystemStatusDto
    {
        [Required(ErrorMessage = "The ID is required.")]
        [EnumDataType(typeof(SystemStatusEnum), ErrorMessage = "Invalid status ID.")]
        public SystemStatusEnum ID { get; set; }

        [Required(ErrorMessage = "The Name is required.")]
        [MaxLength(100, ErrorMessage = "The Name must be 100 characters or fewer.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description is required.")]
        [MaxLength(255, ErrorMessage = "The Description must be 255 characters or fewer.")]
        public string Description { get; set; }
    }
}
