using System.ComponentModel.DataAnnotations;

namespace Sms.Application.DTOs
{
    public class SubmarineDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required.")]
        [MaxLength(255)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Model is required.")]
        [MaxLength(255)]
        [MinLength(3)]
        public string Model { get; set; }

        [Required(ErrorMessage = "The Commissioned Date is required.")]
        public DateTime CommissionedDate { get; set; }

        [Required(ErrorMessage = "The Status is required.")]
        public int Status { get; set; }
    }
}
