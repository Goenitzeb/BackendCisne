using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Services;

namespace BackendMacetas.Business.Services;

public class EntityUpdater<TBindingModel, TEntity>(IRepository<TEntity> repository, IConverter<TBindingModel, TEntity> converter)
    : IEntityUpdater<TBindingModel, TEntity>
    where TEntity : IEntity
{
    public Task<TEntity> UpdateAsync(int id, TBindingModel bindingModel)
    {
        var entity = converter.Convert(bindingModel);

        entity.Id = id;

        return repository.UpdateAsync(entity);
    }
}
