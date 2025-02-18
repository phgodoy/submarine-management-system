using Sms.Domain.Enums;

namespace Sms.Application.Dtos
{
    public class SubmarineStatusDto
    {
        public SubmarineStatusEnum Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
