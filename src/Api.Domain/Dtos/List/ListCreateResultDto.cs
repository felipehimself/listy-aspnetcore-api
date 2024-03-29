using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.List
{
    public class ListCreateResultDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Category { get; set; }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<ListItemInListDto> ListItems { get; set; }
    }
}