using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {

        Task<T> AddAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();

    }
}