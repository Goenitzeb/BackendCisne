using BackendMacetas.Contracts.Data;

namespace BackendMacetas.Contracts.Services;

public interface IEntityDeleter<TEntity>
    where TEntity : IEntity
{
    Task DeleteAsync(int id);
}
