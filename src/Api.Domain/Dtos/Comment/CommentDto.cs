using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Comment
{
    public class CommentDto
    {
        public Guid Id { get; set; }

        public string Comment { get; set; }
    }
}