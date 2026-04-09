using BackendMacetas.Contracts.Data;

namespace BackendMacetas.Contracts.Services;

public interface IGetter<TEntity>
    where TEntity : IEntity
{
    Task<TEntity> GetAsync(int id);
}
