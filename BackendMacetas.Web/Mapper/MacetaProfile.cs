using AutoMapper;
using BackendMacetas.Contracts.Data;
using BackendMacetas.BindingModels; 

public class MacetaProfile : Profile
{
    public MacetaProfile()
    {
        CreateMap<MacetaDTO, Maceta>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}