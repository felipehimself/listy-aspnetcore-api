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

        public async Task<ListEntity?> AddList(ListEntity list)
        {

            // todo:
            // ver se é encessário pois será que o jwt ja nao pode validar?
            // var isGuidValid = Guid.TryParse(list.UserId.ToString(), out _);

            // if (!isGuidValid) return null;

            // var userExists = await _context.Users.AnyAsync(x => x.Id == list.UserId);

            // if (!userExists) return null;


            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var listId = Guid.NewGuid();
                list.Id = listId;

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

        public async Task<ListEntity?> UpdateList(ListEntity list)
        {
            try
            {

                var listFromDb = await _dbSet.Include(x => x.ListItems).FirstOrDefaultAsync(x => x.Id == list.Id);

                if (listFromDb == null) return null;

                var now = DateTime.UtcNow;
                list.UpdatedAt = now;


                var updateListItems = listFromDb.ListItems.Select(itemFromdb =>
                {
                    var findItem = list.ListItems.First(itemInDto => itemInDto.Id == itemFromdb.Id);

                    if (findItem != null)
                    {

                        itemFromdb.Content = findItem.Content;
                        itemFromdb.UpdatedAt = now;
                    }

                    return itemFromdb;

                }).ToList();


                list.ListItems = updateListItems;

                _context.Entry(listFromDb).CurrentValues.SetValues(list);

                await _context.SaveChangesAsync();


                return list;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}