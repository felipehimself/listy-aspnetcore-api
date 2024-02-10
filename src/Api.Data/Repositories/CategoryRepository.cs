using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities.Category;
using Api.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
    {
        DbSet<CategoryEntity> _dbSet;

        public CategoryRepository(MyContext context) : base(context)
        {
            _dbSet = context.Set<CategoryEntity>();
        }
    }
}