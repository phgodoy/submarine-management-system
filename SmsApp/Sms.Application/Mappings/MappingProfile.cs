using AutoMapper;
using Sms.Application.DTOs;
using Sms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SubmarineSystem, SubmarineSystemDTO>();
        }
    }
}
