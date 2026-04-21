using BackendMacetas.Contracts.Data;


namespace BackendMacetas.Contracts.Services;
public interface IEntityCreator<TBindingModel, TEntity> 
    where TEntity : IEntity
{
    Task<TEntity> CreateAsync(TBindingModel bindingModel);
}
