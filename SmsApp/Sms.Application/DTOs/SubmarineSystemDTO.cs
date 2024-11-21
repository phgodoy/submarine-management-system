using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Application.DTOs
{
    public class SubmarineSystemDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required.")]
        [MaxLength(255)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Type is required.")]
        [MaxLength(255)]
        [MinLength(3)]
        public string Type { get; set; }

        [Required(ErrorMessage = "The Operational Status is required.")]
        [MaxLength(255)]
        [MinLength(3)]
        public string OperationalStatus { get; set; }

        [Required(ErrorMessage = "The Last Maintenance Date is required.")]
        public DateTime LastMaintenanceDate { get; set; }
    }
}
