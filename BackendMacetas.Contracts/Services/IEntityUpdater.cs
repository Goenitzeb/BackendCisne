using BackendMacetas.Contracts.Data;

namespace BackendMacetas.Contracts.Services;

public interface IEntityUpdater<TBindingModel,  TEntity> 
    where TEntity : IEntity
{
    Task <TEntity> UpdateAsync(int id, TBindingModel bindingModel);
}
