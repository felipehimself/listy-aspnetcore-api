using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Dtos.List;
using Api.Domain.Entities.List;
using Api.Domain.Entities.User;
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

        public async Task<ListEntity?> GetList(Guid id)
        {
            return await _dbSet.Include(x => x.User)
                .Include(x => x.ListItems)
                .Include(x => x.Comments)
                .ThenInclude(y => y.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ListEntity>> GetLists()
        {
            return await _dbSet.Include(x => x.User).Include(x => x.ListItems).ToListAsync();
        }

        public async Task<ListEntity?> GetListWithItems(Guid id)
        {
            return await _dbSet.Include(x => x.ListItems).FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}