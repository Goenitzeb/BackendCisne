namespace BackendMacetas.Contracts.Data;

public interface IRepository<TEntity>
    where TEntity : IEntity
{
    Task<TEntity> CreateAsync(TEntity entity);

    Task<TEntity> GetAsync(int id);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task DeleteAsync(int id);

    Task DeleteAsync(TEntity entity);

    Task<List<TEntity>> GetAllAsync();
}
