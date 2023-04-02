using Data.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly MyContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public virtual async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveAsync();
            return entity;
        }
        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
            return entity;
        }
       
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<int> SaveAsync()
        {
            return  await _context.SaveChangesAsync();
        }
        public async void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
