using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Application.InterFaces
{
    public interface IReposatory<T> where T : class
    {
        // Get all
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes );

        // Get by 
        Task<T?> FindAsync( int id );
        Task<T?> FindAsync( Expression<Func<T,bool>> predicate );
        Task<T?> FindAsync( Expression<Func<T,bool>> predicate,
                               params Expression<Func<T, object>>[] includes);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate,
                                          params Expression<Func<T, object>>[] includes);

        // Exist

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        // Add
        Task AddAsync(T entity);
        // Add Range
        Task AddRangeAsync(IEnumerable<T> entities);
        // Update
        void Update(T entity);
        // Soft Delete
        void SoftDelete(T entity);
        // Hard Delete 
        void Delete(T entity);
        // Restore
        void Restore(T entity);
        // Count
        Task<int> CountAsync();


    }
}
