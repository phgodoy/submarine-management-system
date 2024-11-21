using Sms.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Application.Interfaces
{
    public interface ISubmarineSystemService
    {
        Task<IEnumerable<SubmarineSystemDTO>> GetSubmarineSystems();
    }
}
