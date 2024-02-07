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
    public class ListItemRepository : BaseRepository<ListItemEntity>, IListItemRepository
    {
        public readonly DbSet<ListItemEntity> _dbSet;
        
        public ListItemRepository(MyContext context) : base(context)
        {
            _dbSet = context.Set<ListItemEntity>();
        }
    }
}