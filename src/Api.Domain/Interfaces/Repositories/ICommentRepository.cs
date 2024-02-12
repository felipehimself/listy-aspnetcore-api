using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities.Comment;

namespace Api.Domain.Interfaces.Repositories
{
    public interface ICommentRepository : IGenericRepository<CommentEntity>
    {

    }
}