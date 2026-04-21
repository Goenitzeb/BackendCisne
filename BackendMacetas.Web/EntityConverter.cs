using AutoMapper;
using BackendMacetas.Contracts.Services;

namespace BackendMacetas;

public class EntityConverter<TSource, TDestination>(IMapper mapper): IConverter<TSource, TDestination>
{
    public TDestination Convert(TSource source)
    {
        return mapper.Map<TDestination>(source);
    }

}
