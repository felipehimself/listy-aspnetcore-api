using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Comment;

namespace Api.Domain.Dtos.List
{
    public class ListSingleDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Category { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public virtual IEnumerable<ListItemInListDto> ListItems { get; set; }

        public virtual IEnumerable<CommentListDto> Comments { get; set; }

    }
}