using ClinicSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Application.InterFaces
{
    public interface IUnitOfWork : IDisposable
    {
        IReposatory<T> Reposatory<T>() where T : BaseEntity;


        // transactions
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task Commit

    }
}
