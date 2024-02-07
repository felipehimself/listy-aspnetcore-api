using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities.List;
using Api.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class ListRepository : BaseRepository<ListEntity>, IListRepository
    {

        public readonly DbSet<ListEntity> _dbSet;

        public readonly MyContext _context;


        public ListRepository(MyContext context) : base(context)
        {
            _dbSet = context.Set<ListEntity>();
            _context = context;
        }

        public async Task<ListEntity> AddList(ListEntity list)
        {


            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var listId = Guid.NewGuid();
                list.Id = listId;

                var now = DateTime.UtcNow;
                list.CreatedAt = now;

                foreach (var item in list.ListItems)
                {
                    item.CreatedAt = now;
                }

                await _dbSet.AddAsync(list);

                await _context.SaveChangesAsync();

                transaction.Commit();

                return list;
            }
            catch (System.Exception)
            {

                transaction.Rollback();
                throw;
            }
        }

        public async Task<IEnumerable<ListEntity>> GetLists()
        {
            return await _dbSet.Include(x => x.ListItems).ToListAsync();
        }
    }
}