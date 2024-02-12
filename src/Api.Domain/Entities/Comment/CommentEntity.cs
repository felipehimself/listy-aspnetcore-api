using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities.List;
using Api.Domain.Entities.User;

namespace Api.Domain.Entities.Comment
{
    public class CommentEntity : BaseEntity
    {

        public Guid ListId { get; set; }

        public Guid UserId { get; set; }

        public string Comment { get; set; }

        public virtual UserEntity User { get; set; }

        public virtual ListEntity List { get; set; }

    }
}