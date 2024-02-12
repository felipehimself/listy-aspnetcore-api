using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities.Comment;
using Api.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api.Data.Repositories
{
    public class CommentRepository : BaseRepository<CommentEntity>, ICommentRepository
    {
        public DbSet<CommentEntity> _dbSet;

        public CommentRepository(MyContext context) : base(context)
        {
            _dbSet = context.Set<CommentEntity>();
        }
    }
}