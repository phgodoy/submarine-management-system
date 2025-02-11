using AutoMapper;
using Sms.Application.DTOs;
using Sms.Application.Submarines.Commands;
using Sms.Domain.Entities;

namespace Sms.Application.Mappings
{
    public class SubmarineMappingProfile : Profile
    {
        public SubmarineMappingProfile()
        {
            // Mapeia DTO para Comando
            CreateMap<SubmarineDto, CreateSubmarineCommand>();

            // Mapeia Comando para Entidade de Domínio
            CreateMap<CreateSubmarineCommand, Submarine>();

            // Mapeia Entidade de Domínio para DTO
            CreateMap<Submarine, SubmarineDto>();
        }
    }
}
