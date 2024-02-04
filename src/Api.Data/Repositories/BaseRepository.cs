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

        private async Task<bool> ExistsAsync(Guid id)
        {
            var exists = await _dataset.AnyAsync(x => x.Id.Equals(id));

            return exists;
        }

        public async Task<T> AddAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                item.CreatedAt = DateTime.UtcNow;

                _dataset.Add(item);

                await _context.SaveChangesAsync();

                return item;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var exists = await ExistsAsync(id);

                if (!exists) return false;

                var res = await GetByIdAsync(id);

                _dataset.Remove(res!);
                await _context.SaveChangesAsync();
                return true;


            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            try
            {
                var exists = await ExistsAsync(id);

                if (!exists) return null;

                return await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<T?> UpdateAsync(T item)
        {
            try
            {

                var result = await GetByIdAsync(item.Id);

                if (result == null) return null;

                item.UpdatedAt = DateTime.UtcNow;
                item.CreatedAt = result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(item);

                await _context.SaveChangesAsync();


                return item;

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}