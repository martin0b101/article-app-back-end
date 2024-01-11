using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Articles.Domain;
using Microsoft.EntityFrameworkCore;

namespace Articles.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity, new()
    {
        protected ApplicationDbContext _dbContext { get; set; }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public IQueryable<T> Query()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        // added this for testing
        public async Task<List<T>> GetAllAsync(){
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task InsertAsync(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;

            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            
            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}