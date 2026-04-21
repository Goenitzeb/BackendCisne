using AutoMapper;
using BackendMacetas.BindingModels;
using BackendMacetas.Contracts.Data;

namespace BackendMacetas.Mapper;

public class ModeloProfile : Profile
{
    public ModeloProfile()
    {
        CreateMap<ModeloDTO, Modelo>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}