using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Comment;
using Api.Domain.Entities.Comment;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using AutoMapper;

namespace Api.Service.Services.Comment
{
    public class CommentService : ICommentService
    {

        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;


        public CommentService(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<CommentCreateResultDto> AddComment(CommentCreateDto comment)
        {


            var entity = _mapper.Map<CommentEntity>(comment);

            var result = await _repository.AddAsync(entity);

            return _mapper.Map<CommentCreateResultDto>(result);


        }

        public async Task<bool> DeleteComment(Guid commentId, Guid userId)
        {
            var comment = await _repository.GetByIdAsync(commentId);

            if (comment == null) return false;

            if (comment.UserId != userId) throw new UnauthorizedAccessException();

            return await _repository.DeleteAsync(commentId);

        }

        public async Task<bool> UpdateComment(CommentUpdateDto comment)
        {
            var originalComment = await _repository.GetByIdAsync(comment.Id);

            if (originalComment == null) return false;

            if (originalComment.UserId != comment.UserId) throw new UnauthorizedAccessException();

            var entity = _mapper.Map<CommentEntity>(comment);

            entity.ListId = originalComment.ListId;

            await _repository.UpdateAsync(entity);

            return true;
        }
    }
}