using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
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

        public async Task<ListEntity?> AddList(ListEntity list)
        {

            var isGuidValid = Guid.TryParse(list.UserId.ToString(), out _);

            if (!isGuidValid) return null;


            var userExists = await _context.Users.AnyAsync(x => x.Id == list.UserId);

            if(!userExists) return null;


            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var listId = Guid.NewGuid();
                list.Id = listId;

                var myid = listId;

                var now = DateTime.UtcNow;
                list.CreatedAt = now;

                foreach (var item in list.ListItems)
                {
                    // item.Id = Guid.NewGuid();
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
            return await _dbSet.Include(x => x.User).Include(x => x.ListItems).ToListAsync();
        }
    }
}