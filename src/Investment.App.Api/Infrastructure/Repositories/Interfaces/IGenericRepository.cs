using System.Linq.Expressions;

namespace Investment.App.Api.Infrastructure.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task AddAsync(T entity);
    Task<T> GetByIdAsync(Guid id);
    Task<List<T>> GetAllAsync(bool tracked = true);
    Task UpdateAsync(T entity);
    Task DeleteByIdAsync(Guid id);
    Task SaveAsync();
}