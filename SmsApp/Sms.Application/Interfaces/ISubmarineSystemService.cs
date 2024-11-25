using Sms.Application.DTOs;

namespace Sms.Application.Interfaces
{
    public interface ISubmarineSystemService
    {
        Task<IEnumerable<SubmarineSystemDTO>> GetSubmarineSystems();
        Task <SubmarineSystemDTO> GetSubmarineSystemById(int id);
    }
}
