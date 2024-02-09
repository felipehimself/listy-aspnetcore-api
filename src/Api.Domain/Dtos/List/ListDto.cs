using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;

namespace Api.Domain.Dtos.List
{
    public class ListDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Category { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public virtual IEnumerable<ListItemInListDto> ListItems { get; set; }


    }
}