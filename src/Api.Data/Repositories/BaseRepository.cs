using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class BaseRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly MyContext _context;
        private readonly DbSet<T> _dataset;


        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();

        }


        public async Task<T> AddAsync(T entity)
        {
            await _dataset.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}