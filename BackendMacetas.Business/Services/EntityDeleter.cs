using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Services;

namespace BackendMacetas.Business.Services;

public class EntityDeleter<TEntity>(IRepository<TEntity> repository) : IEntityDeleter<TEntity> 
    where TEntity : IEntity
{
    public Task DeleteAsync(int id)
    {
         return repository.DeleteAsync(id);
    }
}