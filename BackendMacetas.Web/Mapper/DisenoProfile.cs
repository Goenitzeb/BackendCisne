using AutoMapper;
using BackendMacetas.BindingModels;
using BackendMacetas.Contracts.Data; 

namespace BackendMacetas.Mapper;

public class DisenoProfile : Profile
{
    public DisenoProfile()
    {
        CreateMap<DisenoDTO, Diseno>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}