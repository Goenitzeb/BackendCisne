using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Services;

namespace BackendMacetas.Business.Services;

public class EntityCreator<TBindingModel, TEntity>(IConverter<TBindingModel, TEntity> converter, IRepository<TEntity> repository) : 
    IEntityCreator<TBindingModel, TEntity> where TEntity : IEntity
{
    public async Task<TEntity> CreateAsync(TBindingModel bindingModel)
    {
        var entity = converter.Convert(bindingModel);

        return await repository.CreateAsync(entity);
    }
}
