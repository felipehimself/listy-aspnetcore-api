using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.List
{
    public class ListItemInListDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        
    }
}