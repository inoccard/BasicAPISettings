using BasicAPISettings.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BasicAPISettings.Api.Data.Repositories.Base;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DataContext context) => _dbSet = context.Set<T>();

    public async Task Add(T entity) => await _dbSet.AddAsync(entity);

    public async Task AddRange(IEnumerable<T> entities) => await _dbSet.AddRangeAsync(entities);

    public void Remove(T item) => _dbSet.Remove(item);

    public void RemoveRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);

    public void Update(T entity) => _dbSet.Update(entity);

    public void UpdateRange(IEnumerable<T> entities) => _dbSet.UpdateRange(entities);

    public async Task<T[]> GetAll() => await _dbSet.AsNoTracking().ToArrayAsync();

    public async Task<T> GetByIdAsync(long id) => await _dbSet.FindAsync(id);
}
