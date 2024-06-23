using Investment.App.Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Investment.App.Api.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly InvestmentDbContext _databaseContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(InvestmentDbContext context)
        {
            _databaseContext = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);

            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
                await SaveAsync();
            }
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id) ?? throw new Exception($"{id} wasn't found");
        }

        public async Task<List<T>> GetAllAsync(bool tracked = true)
        {
            IQueryable<T> query = _dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }