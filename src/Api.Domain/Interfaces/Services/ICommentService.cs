using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Comment;
using Api.Domain.Entities.Comment;

namespace Api.Domain.Interfaces.Services
{
    public interface ICommentService
    {
        Task<CommentCreateResultDto> AddComment(CommentCreateDto comment);
        Task<bool> DeleteComment(Guid commentId, Guid userId);
    }
}