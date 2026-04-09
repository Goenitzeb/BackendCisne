namespace BackendMacetas.Contracts.Services;

public interface ICollectionGetter<TEntity>
{
    Task<List<TEntity>> GetAllAsync();
}
