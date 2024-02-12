using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Comment
{
    public class CommentCreateResultDto
    {
        public Guid Id { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}