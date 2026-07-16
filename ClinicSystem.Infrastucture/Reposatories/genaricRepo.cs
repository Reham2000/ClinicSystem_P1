using ClinicSystem.Application.InterFaces;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Infrastucture.Reposatories
{
    public class genaricRepo<T> : IReposatory<T> where T : BaseEntity
    {

        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public genaricRepo(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync() => await _table.ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table;
            foreach (var include in includes)
                query = query.Include(include);
            return await query.ToListAsync();
        }
        public async Task<T?> FindAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _table.FirstOrDefaultAsync(predicate);
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate,
                                  params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table;
            foreach (var include in includes)
                query = query.Include(include);
            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _table.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate,
                                                 params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table;
            foreach (var include in includes)
                query = query.Include(include);
            return await query.Where(predicate).ToListAsync();
        }
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _table.AnyAsync(predicate);
        }
        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _table.AddRangeAsync(entities);
        }
        public void Update(T entity)
        {
            _table.Update(entity);
        }
        public void Delete(T entity)
        {
            _table.Remove(entity);
        }
        public void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.Now;
            Update(entity);
        }
        public async Task<int> CountAsync()
        {
            return await _table.CountAsync();
        }

        public void Restore(T entity)
        {
            entity.IsDeleted = false;
            entity.DeletedAt = null;
            Update(entity);
        }

        

        
    }
}
