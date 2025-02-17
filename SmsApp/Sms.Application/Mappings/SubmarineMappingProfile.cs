using AutoMapper;
using Sms.Application.Submarines.Commands;
using Sms.Application.Dtos;

namespace Sms.Application.Mappings
{
    public class SubmarineMappingProfile : Profile
    {
        public SubmarineMappingProfile()
        {
            // Mapping Dto for comand
            CreateMap<SubmarineDto, CreateSubmarineCommand>();

            // Mapeia Comando para Entidade de Domínio
            CreateMap<CreateSubmarineCommand, Submarine>();

            // Mapeia Entidade de Domínio para DTO
            CreateMap<Submarine, SubmarineDto>();
        }
    }
}
