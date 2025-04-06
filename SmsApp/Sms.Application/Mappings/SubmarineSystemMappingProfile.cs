using AutoMapper;
using Sms.Application.Dtos;
using Sms.Domain.Entities;
using Sms.Application.SubmarineSystems.Commands;


namespace Sms.Application.Mappings
{
    public class SubmarineSystemMappingProfile : Profile
    {
        public SubmarineSystemMappingProfile()
        {
            // Maps SubmarineSystemDto to CreateSubmarineCommand
            CreateMap<SubmarineSystemDto, CreateSubmarineSystemCommand>();

            // Maps CreateSubmarineCommand to the Domain Entity Submarine
            CreateMap<CreateSubmarineSystemCommand, Submarine>();
            CreateMap<UpdateSubmarineSystemCommand, Submarine>();

            // Maps the Domain Entity SubmarineSystem to SystemStatusDto and includes SystemStatus mapping
            CreateMap<SubmarineSystem, SubmarineSystemDto>()
                .ForMember(dest => dest.SystemStatusDto, opt => opt.MapFrom(src => src.SystemStatus));

            // Maps SystemStatus to SystemStatusDto
            CreateMap<SystemStatus, SystemStatusDto>();
        }
    }
}
