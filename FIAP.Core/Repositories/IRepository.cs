using FIAP.Core.Entities;

namespace FIAP.Core.Repositories;

public interface IRepository<T> where T : DefaultEntity
{
    Task<T> AddAsync(T entity);
    Task<T?> GetAsync(uint id);
    Task<IList<T>> GetAsync();
    Task<bool> UpdateAsync(T entity);
    Task<bool> RemoveAsync(uint id);
}
