using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Services;

namespace BackendMacetas.Business.Services;

public class Getter<TEntity>(
    IRepository<TEntity> repository) : IGetter<TEntity>
    where TEntity : class, IEntity
{
    public Task<TEntity> GetAsync(int id)
    {
        // TODO: Add Validaciones
        return repository.GetAsync(id);
    }
}
