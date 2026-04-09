using BackendMacetas.Contracts.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendMacetas.Database.Data;

public class Repository<TEntity>(AppDbContext context) : IRepository<TEntity>
    where TEntity : class, IEntity
{
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        var createdEntity = context.Set<TEntity>().Add(entity).Entity;
        await context.SaveChangesAsync();
        return createdEntity;
    }

    public async Task<TEntity> GetAsync(int id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var updatedEntity = context.Set<TEntity>().Update(entity).Entity;
        await context.SaveChangesAsync();
        return updatedEntity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity {nameof(Maceta)} with id {id} not found.");
        context.Set<TEntity>().Remove(entity);
        await context.SaveChangesAsync();
    }

    public Task DeleteAsync(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
        return context.SaveChangesAsync();
    }

    public Task<List<TEntity>> GetAllAsync()
    {
        return context.Set<TEntity>().ToListAsync();
    }
}
