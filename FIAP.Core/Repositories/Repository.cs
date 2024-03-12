using FIAP.Core.Data;
using FIAP.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Core.Repositories;

public class Repository<T> : IRepository<T> where T : DefaultEntity
{
    protected ApplicationDbContext _context;
    protected DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T?> GetAsync(uint id)
    {
        return await _dbSet.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IList<T>> GetAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException)
        {
            return false;
        }
    }

    public async Task<bool> RemoveAsync(uint id)
    {
        var entity = await GetAsync(id);
        if (entity is not null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
