using AutoMapper;
using Sms.Application.Commands;
using Sms.Application.DTOs;
using Sms.Application.SubmarineSystems.Commands;
using Sms.Domain.Entities;

public class SubmarineSystemMappingProfile : Profile
{
    public SubmarineSystemMappingProfile()
    {
        // Mapeia DTO para Comando
        CreateMap<SubmarineSystemDTO, CreateSubmarineSystemCommand>();

        // Mapeia Comando para Entidade de Domínio
        CreateMap<CreateSubmarineSystemCommand, SubmarineSystem>();

        // Mapeia Entidade de Domínio para DTO
        CreateMap<SubmarineSystem, SubmarineSystemDTO>();
    }
}
