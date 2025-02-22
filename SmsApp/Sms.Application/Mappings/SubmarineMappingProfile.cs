using AutoMapper;
using Sms.Application.Submarines.Commands;
using Sms.Application.Dtos;
using Sms.Domain.Entities;

namespace Sms.Application.Mappings
{
    public class SubmarineMappingProfile : Profile
    {
        public SubmarineMappingProfile()
        {
            // Maps SubmarineDto to CreateSubmarineCommand
            CreateMap<SubmarineDto, CreateSubmarineCommand>();

            // Maps CreateSubmarineCommand to the Domain Entity Submarine
            CreateMap<CreateSubmarineCommand, Submarine>();
            CreateMap<UpdateSubmarineCommand, Submarine>();

            // Maps the Domain Entity Submarine to SubmarineDto and includes SubmarineStatus mapping
            CreateMap<Submarine, SubmarineDto>()
                .ForMember(dest => dest.SubmarineStatusDto, opt => opt.MapFrom(src => src.SubmarineStatus));

            // Maps SubmarineStatus to SubmarineStatusDto
            CreateMap<SubmarineStatus, SubmarineStatusDto>();
        }
    }
}
