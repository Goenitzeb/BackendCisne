using AutoMapper;
using BackendMacetas.BindingModels;
using BackendMacetas.Contracts.Data;

namespace BackendMacetas.Mapper;

public class MainProfile : Profile
{
    public MainProfile()
    {
        CreateMap<ColorDTO, Color>();

        CreateMap<TamanoDTO, Tamano>();

        CreateMap<ModeloDTO, Modelo>();

        CreateMap<MacetaDTO, Maceta>();

        CreateMap<DisenoDTO, Diseno>();
    }
}