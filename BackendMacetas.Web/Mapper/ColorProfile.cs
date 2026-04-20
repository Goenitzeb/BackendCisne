using AutoMapper;
using BackendMacetas.BindingModels;
using BackendMacetas.Contracts.Data;

namespace BackendMacetas.Mapper;

public class ColorProfile : Profile
{
    public ColorProfile()
    {
        CreateMap<ColorDTO, Color>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}