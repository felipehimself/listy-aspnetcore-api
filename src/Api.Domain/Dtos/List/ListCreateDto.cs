using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.List
{
    public class ListCreateDto
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }

        public IEnumerable<ListItemCreateDto> ListItems { get; set; }
    }
}
