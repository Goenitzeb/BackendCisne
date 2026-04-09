
using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Services;

namespace BackendMacetas.Business.Services;

public class CollectionGetter<TEntity>(IRepository<TEntity> repository) : ICollectionGetter<TEntity>
    where TEntity : IEntity
{
    public Task<List<TEntity>> GetAllAsync()
    {
        return repository.GetAllAsync();
    }
}
