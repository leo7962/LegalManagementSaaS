using AutoMapper;
using LegalManagementSaaS.Application.DTOs;
using LegalManagementSaaS.Domain.Entities;

namespace LegalManagementSaaS.Application.Mappings
{
    public class LegalCaseProfile : Profile
    {
        public LegalCaseProfile()
        {
            CreateMap<LegalCase, LegalCaseDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}
