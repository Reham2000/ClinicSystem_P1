using ClinicSystem.Application.InterFaces;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Infrastucture.Data;
using ClinicSystem.Infrastucture.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Infrastucture.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        private readonly Dictionary<Type, object> _repositories = new();
        public IReposatory<T> Reposatory<T>() where T : BaseEntity
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IReposatory<T>)_repositories[typeof(T)];
            }

            var repo = new genaricRepo<T>(_context);
            _repositories.Add(typeof(T), repo);
            return repo;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
